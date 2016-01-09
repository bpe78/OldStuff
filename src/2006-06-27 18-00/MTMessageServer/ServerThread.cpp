// ServerThread.cpp : implementation file
//

#include "stdafx.h"
#include "resource.h"
#include "ServerThread.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CServerThread

IMPLEMENT_DYNCREATE(CServerThread, CWinThread)

CServerThread::CServerThread()
{
  m_lInterval = 1000;
  m_bSignalTerminate = FALSE;
}

CServerThread::~CServerThread()
{
}

BOOL CServerThread::InitInstance()
{
  CoInitialize(NULL);
  
  HRESULT hr = CoCreateInstance(CLSID_Logger, NULL, CLSCTX_INPROC_SERVER, IID_ILogger, (void**)&m_spLogger);
  ASSERT(SUCCEEDED(hr));
  
  // start log operation
  if(m_spLogger != NULL)
  {
    m_spLogger->AddLogEntry(ET_MsgSThreadStarted, GetCurrentThreadId(), 0, L"");
  }
  // end log operation

  return TRUE;
}

int CServerThread::ExitInstance()
{
  // start log operation
  if(m_spLogger != NULL)
  {
    m_spLogger->AddLogEntry(ET_MsgSThreadStopped, GetCurrentThreadId(), 0, L"");
  }
  // end log operation
  
  // cleanup before uninitializing COM  
  m_spMessageQueue = NULL;
  m_spLogger = NULL;
  
  CoUninitialize();

  return CWinThread::ExitInstance();
}

BEGIN_MESSAGE_MAP(CServerThread, CWinThread)
	//{{AFX_MSG_MAP(CServerThread)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CServerThread message handlers

int CServerThread::Run() 
{
  HRESULT hr;
  VARIANT vtCanPopMessages;
  BSTR bstrMessage;

  while(!m_bSignalTerminate)
  {
    if(m_spMessageQueue != NULL)
    {
      hr = m_spMessageQueue->CanPopMessages(&vtCanPopMessages);
      ASSERT(SUCCEEDED(hr) && (vtCanPopMessages.vt == VT_BOOL));
      if(vtCanPopMessages.boolVal)
      {
        hr = m_spMessageQueue->PopMessage(&vtCanPopMessages, &bstrMessage);
        ASSERT(SUCCEEDED(hr) && (vtCanPopMessages.vt == VT_BOOL));

        if(vtCanPopMessages.boolVal == TRUE)
        {
          // start log operation
          if(m_spLogger != NULL)
          {
            hr = m_spLogger->AddLogEntry(ET_MsgMessagePop, GetCurrentThreadId(), 0, bstrMessage);
            ASSERT(SUCCEEDED(hr));
          }
          // end log operation
        }
      }
    }
    if(m_bSignalTerminate)
      break;
    Sleep(m_lInterval);
  }

  return 0;
}


void CServerThread::UpdateConfiguration(IMessageQueue* pIMessageQueue, long lInterval)
{
  m_spMessageQueue = pIMessageQueue;
  m_lInterval = lInterval;
}

void CServerThread::SignalTerminate()
{
  m_bSignalTerminate = TRUE;
}
