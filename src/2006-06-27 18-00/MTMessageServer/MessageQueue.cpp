// MessageQueue.cpp : Implementation of CMessageQueue
#include "stdafx.h"
#include "MTMessageServer.h"
#include "MessageQueue.h"
#include "ClientThread.h"

/////////////////////////////////////////////////////////////////////////////
// CMessageQueue

CMessageQueue::CMessageQueue()
{
  m_UIListener = 0;
  m_iInternalCounter = 0;
  
  m_lSleepTimeClients = 1;
  m_lSleepTimeServers = 1;
  
  m_lMinMessages = 0;
  m_lMaxMessages = 0;

  InitializeCriticalSection(&m_cs);

  // start log operation
  if(IsLoggerAvailable())
    m_spLogger->AddLogEntry((byte)ET_MsgServerStart, 0, 0, L"");
  // end log operation
}

CMessageQueue::~CMessageQueue()
{
  // start log operation
  if(IsLoggerAvailable())
    m_spLogger->AddLogEntry((byte)ET_MsgServerStop, 0, 0, L"");
  // end log operation
}


STDMETHODIMP CMessageQueue::AddUIListener(long lThreadID)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())

  m_UIListener = lThreadID;

  return S_OK;
}

STDMETHODIMP CMessageQueue::PushMessage(long lThreadID, BSTR bstrMessage)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  // validation
  if(!m_listMessages.CanPushMessage())
  {
    // start log operation
    if(IsLoggerAvailable())
      m_spLogger->AddLogEntry(ET_MsgErrorQueueOverflow, GetCurrentThreadId(), m_lMaxMessages, L"");
    // end log operation

    return S_FALSE;
  }

  // add message to internal queue
  char *szBuffer = (char *)CoTaskMemAlloc(100);
  wcstombs(szBuffer, bstrMessage, 100);
  CString strMessage;
  strMessage.Format("%05d : ID = %d - Message = %s", ++m_iInternalCounter, lThreadID, szBuffer);
  m_listMessages.PushMessage(strMessage);

  // send message to UI control
  sprintf(szBuffer, "%s", strMessage);
  ::PostThreadMessage(m_UIListener, TM_AddMessage, 0, (LPARAM)szBuffer);

	return S_OK;
}

STDMETHODIMP CMessageQueue::PopMessage(VARIANT *pvtValid, BSTR *pbstrMessage)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())

  VariantInit(pvtValid);
  pvtValid->vt = VT_BOOL;

  if(!m_listMessages.CanPopMessage())
  {
    // start log operation
    if(IsLoggerAvailable())
      m_spLogger->AddLogEntry(ET_MsgErrorQueueUnderflow, GetCurrentThreadId(), m_lMinMessages, L"");
    // end log operation

    pvtValid->boolVal = FALSE;
    *pbstrMessage = SysAllocString(CComBSTR(L""));  // this will be deallocated in the client
  }
  else
  {
    CString strTmp;
    m_listMessages.PopMessage(strTmp);

    // set results
    pvtValid->boolVal = TRUE;
    *pbstrMessage = SysAllocString(CComBSTR(strTmp));
  
    // send message to UI control
    PostThreadMessage(m_UIListener, TM_DelMessage, 0, 0);
  }

  return S_OK;
}


STDMETHODIMP CMessageQueue::UpdateConfiguration(VARIANT vtInitialize,
                                                long lNbClientThreadsStart, long lNbServerThreadsStart,
                                                long lNbClientThreadsStop, long lNbServerThreadsStop,
                                                long lSleepTimeClients, long lSleepTimeServers,
                                                long lMinMessages, long lMaxMessages)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  ASSERT(vtInitialize.vt == VT_I4);

  // start a specified number of client threads
  if((vtInitialize.lVal & C_ClientThreadsStart) == C_ClientThreadsStart)
  {
    StartClientThreads(lNbClientThreadsStart);

    // start log operation
    if(IsLoggerAvailable())
    {
      m_spLogger->AddLogEntry(ET_MsgCThreadChanged, 0, lNbClientThreadsStart, L"Clients started");
    }
    // end log operation    
  }

  // start a specified number of server threads
  if((vtInitialize.lVal & C_ServerThreadsStart) == C_ServerThreadsStart)
  {
    StartServerThreads(lNbServerThreadsStart);

    // start log operation
    if(IsLoggerAvailable())
    {
      m_spLogger->AddLogEntry(ET_MsgSThreadChanged, 0, lNbServerThreadsStart, L"Servers started");
    }
    // end log operation    
  }

  // stop a specifed number of client threads
  if((vtInitialize.lVal & C_ClientThreadsStop) == C_ClientThreadsStop)
  {
    StopClientThreads(lNbClientThreadsStop);
    
    // start log operation
    if(IsLoggerAvailable())
    {
      m_spLogger->AddLogEntry(ET_MsgCThreadChanged, 0, lNbClientThreadsStop, L"Clients stoppped");
    }
    // end log operation    
  }
  
  // stop a specifed number of server threads
  if((vtInitialize.lVal & C_ServerThreadsStop) == C_ServerThreadsStop)
  {
    StopServerThreads(lNbServerThreadsStop);
    
    // start log operation
    if(IsLoggerAvailable())
    {
      m_spLogger->AddLogEntry(ET_MsgSThreadChanged, 0, lNbServerThreadsStop, L"Servers stopped");
    }
    // end log operation    
  }

  // if this value changed, update all clients' configuration
  if((vtInitialize.lVal & C_SleepTimeClients) == C_SleepTimeClients)
  {
    m_lSleepTimeClients = lSleepTimeClients;

    std::list<CClientThread*>::iterator It;
    for(It = m_vecClientThreads.begin(); It != m_vecClientThreads.end(); It++)
    {
      CClientThread *pThread = *It;
      ASSERT(pThread != NULL);
      if(pThread != NULL)
        pThread->UpdateConfiguration((IMessageQueue*)this, m_lSleepTimeClients);
    }
  }

  // if this value changed, update all servers' configuration
  if((vtInitialize.lVal & C_SleepTimeServers) == C_SleepTimeServers)
  {
    m_lSleepTimeServers = lSleepTimeServers;

    std::list<CServerThread*>::iterator It;
    for(It = m_vecServerThreads.begin(); It != m_vecServerThreads.end(); It++)
    {
      CServerThread *pThread = *It;
      ASSERT(pThread != NULL);
      if(pThread != NULL)
        pThread->UpdateConfiguration((IMessageQueue*)this, m_lSleepTimeServers);
    }
  }

  if((vtInitialize.lVal & C_QueueMinMessages) == C_QueueMinMessages)
  {
    m_lMinMessages = lMinMessages;
    m_listMessages.SetLimits(m_lMinMessages, m_lMaxMessages);

    // start log operation
    if(IsLoggerAvailable())
      m_spLogger->AddLogEntry(ET_MsgQueueMin, 0, m_lMinMessages, L"");
    // end log operation
  }

  if((vtInitialize.lVal & C_QueueMaxMessages) == C_QueueMaxMessages)
  {
    m_lMaxMessages = lMaxMessages;
    m_listMessages.SetLimits(m_lMinMessages, m_lMaxMessages);
    
    // start log operation
    if(IsLoggerAvailable())
      m_spLogger->AddLogEntry(ET_MsgQueueMax, 0, m_lMaxMessages, L"");
    // end log operation    
  }

  return S_OK;
}

STDMETHODIMP CMessageQueue::CanPushMessages(VARIANT *pvtCanPushMessages)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  pvtCanPushMessages->vt = VT_BOOL;
  pvtCanPushMessages->boolVal = m_listMessages.CanPushMessage();

	return S_OK;
}

STDMETHODIMP CMessageQueue::CanPopMessages(VARIANT *pvtCanPopMessages)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  pvtCanPopMessages->vt = VT_BOOL;
  pvtCanPopMessages->boolVal = m_listMessages.CanPopMessage();

  return S_OK;
}

void CMessageQueue::StartClientThreads(long lClients)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  for(int i=0; i<lClients; i++)
  {
    CClientThread *pThread = (CClientThread*)AfxBeginThread(RUNTIME_CLASS(CClientThread), THREAD_PRIORITY_BELOW_NORMAL);
    ASSERT(pThread != NULL);
    m_vecClientThreads.push_back(pThread);
    pThread->UpdateConfiguration((IMessageQueue*)this, m_lSleepTimeClients);
  }
}

void CMessageQueue::StopClientThreads(long lClients)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())

  // if there are fewer threads running, stop them all
  if(lClients > m_vecClientThreads.size())
    lClients = m_vecClientThreads.size();

  for(int i=0; i<lClients; i++)
  {
    CClientThread *pThread = m_vecClientThreads.front();
    if(pThread != NULL)
    {
      pThread->SignalTerminate();
    }
    m_vecClientThreads.pop_front();
  }
}

void CMessageQueue::StartServerThreads(long lServers)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  for(int i=0; i<lServers; i++)
  {
    CServerThread *pThread = (CServerThread*)AfxBeginThread(RUNTIME_CLASS(CServerThread), THREAD_PRIORITY_BELOW_NORMAL);
    ASSERT(pThread != NULL);
    m_vecServerThreads.push_back(pThread);
    pThread->UpdateConfiguration((IMessageQueue*)this, m_lSleepTimeServers);
  }
}

void CMessageQueue::StopServerThreads(long lServers)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  // if there are fewer threads running, stop them all
  if(lServers > m_vecServerThreads.size())
    lServers = m_vecServerThreads.size();

  for(int i=0; i<lServers; i++)
  {
    CServerThread *pThread = m_vecServerThreads.front();
    if(pThread != NULL)
    {
      pThread->SignalTerminate();
    }
    m_vecServerThreads.pop_front();
  }
}

STDMETHODIMP CMessageQueue::ClearQueue()
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  // start log operation
  if(IsLoggerAvailable())
  {
    m_spLogger->AddLogEntry(ET_MsgClearQueue, 0, m_listMessages.Size(), L"");
  }
  // end log operation

  m_listMessages.Clear();

  return S_OK;
}

STDMETHODIMP CMessageQueue::StopQueue()
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  // start log operation
  if(IsLoggerAvailable())
  {
    m_spLogger->AddLogEntry(ET_MsgStopQueue, 0, m_listMessages.Size(), L"");
  }
  // end log operation

  DWORD dwCount = m_vecClientThreads.size() + m_vecServerThreads.size();
  HANDLE *pvecHandles = (HANDLE*)calloc(dwCount, sizeof(HANDLE));
  ASSERT(pvecHandles != NULL);

  int i = 0;
  std::list<CClientThread*>::iterator ItClient;
  for(ItClient = m_vecClientThreads.begin(); ItClient != m_vecClientThreads.end(); ItClient++)
  {
    CClientThread *pThread = *ItClient;
    ASSERT(pThread != NULL);
    if(pThread != NULL)
    {
      pvecHandles[i++] = pThread->m_hThread;
    }
  }

  std::list<CServerThread*>::iterator ItServer;
  for(ItServer = m_vecServerThreads.begin(); ItServer != m_vecServerThreads.end(); ItServer++)
  {
    CServerThread *pThread = *ItServer;
    ASSERT(pThread != NULL);
    if(pThread != NULL)
    {
      pvecHandles[i++] = pThread->m_hThread;
    }
  }

  // stop everyhing
  StopClientThreads(m_vecClientThreads.size());
  StopServerThreads(m_vecServerThreads.size());
  WaitForMultipleObjects(dwCount, pvecHandles, TRUE, 5000);

  m_listMessages.Clear();

  return S_OK;
}

boolean CMessageQueue::IsLoggerAvailable()
{
  if(m_spLogger != NULL)
    return TRUE;
  
  HRESULT hr;
  hr = CoCreateInstance(CLSID_Logger, NULL, CLSCTX_INPROC_SERVER, IID_ILogger, (void**)&m_spLogger);
  if(FAILED(hr))
  {
    m_spLogger = NULL;
    AfxMessageBox("<Log component> not available");
    return FALSE;
  }
  
  return TRUE;
}

STDMETHODIMP CMessageQueue::GetRunningClientThreads(long *plClientsRunning)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  *plClientsRunning = m_vecClientThreads.size();

  return S_OK;
}

STDMETHODIMP CMessageQueue::GetRunningServerThreads(long *plServersRunning)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  *plServersRunning = m_vecServerThreads.size();

	return S_OK;
}
