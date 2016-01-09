// ClientThread.cpp : implementation file
//

#include "stdafx.h"
#include "resource.h"
#include "ClientThread.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CClientThread

IMPLEMENT_DYNCREATE(CClientThread, CWinThread)

CClientThread::CClientThread()
{
  m_lInterval = 1000;
  m_bSignalTerminate = FALSE;
}

CClientThread::~CClientThread()
{
}

BOOL CClientThread::InitInstance()
{
  CoInitialize(NULL);

  HRESULT hr = CoCreateInstance(CLSID_Logger, NULL, CLSCTX_INPROC_SERVER, IID_ILogger, (void**)&m_spLogger);
  ASSERT(SUCCEEDED(hr));

  // start log operation
  if(m_spLogger != NULL)
  {
    m_spLogger->AddLogEntry(ET_MsgCThreadStarted, GetCurrentThreadId(), 0, L"");
  }
  // end log operation
  
  return TRUE;
}

int CClientThread::ExitInstance()
{
  // start log operation
  if(m_spLogger != NULL)
  {
    m_spLogger->AddLogEntry(ET_MsgCThreadStopped, GetCurrentThreadId(), 0, L"");
  }
  // end log operation
  
  // cleanup before uninitializing COM  
  m_spMessageQueue = NULL;
  m_spLogger = NULL;

  CoUninitialize();

	return CWinThread::ExitInstance();
}

BEGIN_MESSAGE_MAP(CClientThread, CWinThread)
	//{{AFX_MSG_MAP(CClientThread)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CClientThread message handlers

int CClientThread::Run() 
{
  HRESULT hr;
  char szBuffer[64] = {0};
  VARIANT vtCanPushMessages;
  
  while(!m_bSignalTerminate)
  {
    VariantInit(&vtCanPushMessages);
    if(m_spMessageQueue != NULL)
    {
      hr = m_spMessageQueue->CanPushMessages(&vtCanPushMessages);
      ASSERT(SUCCEEDED(hr) && (vtCanPushMessages.vt == VT_BOOL));
    }
    if((vtCanPushMessages.vt == VT_BOOL) && (vtCanPushMessages.boolVal == TRUE))
    {
      CTime t = CTime::GetCurrentTime();
      sprintf(szBuffer, "%02d/%02d/%d,%02d:%02d:%02d", t.GetMonth(), t.GetDay(), t.GetYear(), t.GetHour(), t.GetMinute(), t.GetSecond());
      BSTR bstrMessage = CComBSTR(szBuffer);

      hr = m_spMessageQueue->PushMessage(GetCurrentThreadId(), bstrMessage);
      ASSERT(SUCCEEDED(hr));

      // start log operation
      if(m_spLogger != NULL)
      {
        hr = m_spLogger->AddLogEntry(ET_MsgMessagePush, GetCurrentThreadId(), 0, bstrMessage);
        ASSERT(SUCCEEDED(hr));
      }
      // end log operation
    }
    if(m_bSignalTerminate)
      break;
    Sleep(m_lInterval);
  }

	return 0;
}

void CClientThread::UpdateConfiguration(IMessageQueue* pIMessageQueue, long lInterval)
{
  m_spMessageQueue = pIMessageQueue;
  m_lInterval = lInterval;
}

void CClientThread::SignalTerminate()
{
  m_bSignalTerminate = TRUE;
}
