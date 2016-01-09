// Logger.cpp : Implementation of CLogger
#include "stdafx.h"
#include "MTMessageServer.h"
#include "Logger.h"

/////////////////////////////////////////////////////////////////////////////
// CLogger

#define LOG_DEFAULT_FILENAME L"d:\\log.txt"

CLogger::CLogger()
{
  m_eLoggingLevel = LL_All;

  HRESULT hr;
  
  // get options from registry
  // if key not created or filename empty, save default filename
  CComPtr<ISettings> spSettings;
  hr = CoCreateInstance(CLSID_Settings, NULL, CLSCTX_INPROC_SERVER, IID_ISettings, (void**)&spSettings);
  if(SUCCEEDED(hr))
  {
    BSTR bstrFilename;
    hr = spSettings->GetLogFilename(&bstrFilename);
    
    if(SUCCEEDED(hr))
    {
      if(CComBSTR(bstrFilename).Length() == 0)
      {
        hr = spSettings->SetLogFilename(LOG_DEFAULT_FILENAME);
        ASSERT(SUCCEEDED(hr));
      }
    }
    SysFreeString(bstrFilename);

    long lLogLevel = 0;
    hr = spSettings->GetLogLevel(&lLogLevel);
    if(SUCCEEDED(hr))
      m_eLoggingLevel = (eLoggingLevel)lLogLevel;
  }
}


char* CLogger::GetLogFilename()
{
  HRESULT hr;
  BSTR bstrRetVal(LOG_DEFAULT_FILENAME);
  
  // get options from registry
  CComPtr<ISettings> spSettings;
  hr = CoCreateInstance(CLSID_Settings, NULL, CLSCTX_INPROC_SERVER, IID_ISettings, (void**)&spSettings);
  if(SUCCEEDED(hr))
  {
    BSTR bstrFilename;
    hr = spSettings->GetLogFilename(&bstrFilename);

    if(SUCCEEDED(hr))
    {
      // if not empty, retain value, else discard
      if(CComBSTR(bstrFilename).Length() > 0)
        bstrRetVal = bstrFilename;
    }

    SysFreeString(bstrFilename);
  }

  char *pszBuffer = (char*)CoTaskMemAlloc(128);
  wcstombs(pszBuffer, bstrRetVal, 128);
  return pszBuffer;
}

STDMETHODIMP CLogger::DisplayLog()
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  char *szFile = GetLogFilename();

  FILE *pf;
  if((pf = fopen(szFile, "rt")) == NULL)
  {
    AfxMessageBox("Log file does not exist !!!");
    return S_FALSE;
  }
  
  fseek(pf, 0, SEEK_END);
  if(ftell(pf) < 3)
  {
    AfxMessageBox("Log file empty !!!");
    return S_FALSE;
  }
  fclose(pf);
  
  char cmd[128] = {0};
  sprintf(cmd, "notepad %s", szFile);
  WinExec(cmd, SW_SHOW);
  
  CoTaskMemFree(szFile);

	return S_OK;
}

STDMETHODIMP CLogger::AddLogEntry(byte bType, long lThreadID, long lNumber, BSTR bstrDescription)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  eEventType eType = (eEventType)bType;

  // filter incoming events
  if(!FilterMessage(eType))
    return S_OK;

  char *szFile = GetLogFilename();
  FILE *pf;
  if(((pf = fopen(szFile, "at")) == NULL) && 
     ((pf = fopen(szFile, "wt")) == NULL))
  {
    AfxMessageBox("Cannot open log file");
    CoTaskMemFree(szFile);
    return E_FAIL;
  }
  CoTaskMemFree(szFile);

  char sTime[40] = {0};
  CTime t = CTime::GetCurrentTime();
  sprintf(sTime, "%02d/%02d/%d,%02d:%02d:%02d", t.GetMonth(), t.GetDay(), t.GetYear(), t.GetHour(), t.GetMinute(), t.GetSecond());

  char strBuffer[512] = {0};

  switch(eType)
  {
    case ET_MsgClearQueue :           // message queue
    {
      sprintf(strBuffer, "CLEAR QUEUE\n\tTime: %s\n\tMessages erased : %d\n", sTime, lNumber);
    } break;

    case ET_MsgStopQueue :            // message queue
    {
      sprintf(strBuffer, "STOP QUEUE\n\tTime: %s\n", sTime);
    } break;

    case ET_MsgServerStart :          // message queue
    {
      sprintf(strBuffer, "MESSAGE SERVER STARTED\n\tTime: %s\n", sTime);
    } break;

    case ET_MsgServerStop :           // message queue
    {
      sprintf(strBuffer, "MESSAGE SERVER STOPPED\n\tTime: %s\n", sTime);
    } break;

    case ET_MsgQueueMin :             // message queue
    {
      sprintf(strBuffer, "MESSAGES IN QUEUE CHANGED\n\tTime: %s\n\tNumber of min messages: %d\n", sTime, lNumber);
    } break;

    case ET_MsgQueueMax :             // message queue
    {
      sprintf(strBuffer, "MESSAGES IN QUEUE CHANGED\n\tTime: %s\n\tNumber of max messages: %d\n", sTime, lNumber);
    } break;

    case ET_MsgMessagePush :          // client threads
    {
      sprintf(strBuffer, "MESSAGE PUSH\n\tTime: %s\n\tThread ID: %d\n\tContent: %s\n", sTime, lThreadID, CComBSTR(bstrDescription)/*_com_util::ConvertBSTRToString(bstrDescription)*/);
    } break;

    case ET_MsgMessagePop :           // server threads
    {
      sprintf(strBuffer, "MESSAGE POP\n\tTime: %s\n\tThread ID: %d\n\tContent: %s\n", sTime, lThreadID, CComBSTR(bstrDescription)/*_com_util::ConvertBSTRToString(bstrDescription)*/);
    } break;

    case ET_MsgCThreadStarted :       // client threads
    {
      sprintf(strBuffer, "CLIENT THREAD STARTED\n\tTime: %s\n\tThread ID : %d\n", sTime, lThreadID);
    } break;

    case ET_MsgCThreadStopped :        // client threads
    {
      sprintf(strBuffer, "CLIENT THREAD STOPPED\n\tTime: %s\n\tThread ID: %d\n", sTime, lThreadID);
    } break;
      
    case ET_MsgCThreadChanged :       // message queue
    {
      sprintf(strBuffer, "NUMBER OF CLIENT THREADS CHANGED\n\tTime: %s\n\tDelta : %d\n\tDescription : %s\n", sTime, lNumber, CComBSTR(bstrDescription));
    } break;

    case ET_MsgSThreadStarted :       // server threads
    {
      sprintf(strBuffer, "SERVER THREAD STARTED\n\tTime: %s\n\tThread ID : %d\n", sTime, lThreadID);
    } break;

    case ET_MsgSThreadStopped :       // server threads
    {
      sprintf(strBuffer, "SERVER THREAD STOPPED\n\tTime: %s\n\tThread ID : %d\n", sTime, lThreadID);
    } break;

    case ET_MsgSThreadChanged :       // message queue
    {
      sprintf(strBuffer, "NUMBER OF SERVER THREADS CHANGED\n\tTime: %s\n\tDelta : %d\n\tDescription : %s\n", sTime, lNumber, CComBSTR(bstrDescription));
    } break;

    case ET_MsgErrorinRegistry :      // logger
    {
      sprintf(strBuffer, "ERROR in REGISTRY\n\tTime: %s\n\tThread ID : %d\n\tDescription : %s\n", sTime, lThreadID, CComBSTR(bstrDescription)/*_com_util::ConvertBSTRToString(bstrDescription)*/);
    } break;

    case ET_MsgErrorQueueUnderflow :  // message queue
    {
      sprintf(strBuffer, "ERROR in QUEUE\n\tTime: %s\n\tThread ID : %d\n\tMin messages : %d\n", sTime, lThreadID, lNumber);
    } break;
      
    case ET_MsgErrorQueueOverflow :   // message queue
    {
      sprintf(strBuffer, "ERROR in QUEUE\n\tTime: %s\n\tThread ID : %d\n\tMax messages : %d\n", sTime, lThreadID, lNumber);
    } break;

    default :
    {
      sprintf(strBuffer, "ERROR : UNKNOWN MESSAGE !!!\n");
      ASSERT(FALSE);
    } break;
  }

  fprintf(pf, strBuffer);
  fprintf(pf, "\n");
  fclose(pf);

	return S_OK;
}

boolean CLogger::FilterMessage(eEventType eType)
{
  switch(m_eLoggingLevel)
  {
    case LL_None :  // always reject messages
    {
      return FALSE;
    } break;
    case LL_All:    // always accept messages
    {
      return TRUE;
    } break;
  }
  
  eLoggingLevel eMsgLogLevel = LL_None;
  
  switch(eType)
  {
    case ET_MsgClearQueue           : eMsgLogLevel = LL_UserInterface; break;
    case ET_MsgStopQueue            : eMsgLogLevel = LL_UserInterface; break;

    case ET_MsgServerStart          : eMsgLogLevel = LL_UserInterface; break;
    case ET_MsgServerStop           : eMsgLogLevel = LL_UserInterface; break;

    case ET_MsgQueueMin             : eMsgLogLevel = LL_UserInterface; break;
    case ET_MsgQueueMax             : eMsgLogLevel = LL_UserInterface; break;

    case ET_MsgMessagePush          : eMsgLogLevel = LL_Activity;      break;
    case ET_MsgMessagePop           : eMsgLogLevel = LL_Activity;      break;

    case ET_MsgCThreadStarted       : eMsgLogLevel = LL_Activity;      break;
    case ET_MsgCThreadStopped       : eMsgLogLevel = LL_Activity;      break;
    case ET_MsgCThreadChanged       : eMsgLogLevel = LL_UserInterface; break;

    case ET_MsgSThreadStarted       : eMsgLogLevel = LL_Activity;      break;
    case ET_MsgSThreadStopped       : eMsgLogLevel = LL_Activity;      break;
    case ET_MsgSThreadChanged       : eMsgLogLevel = LL_UserInterface; break;
      
    case ET_MsgErrorinRegistry      : eMsgLogLevel = LL_Errors;        break;
    case ET_MsgErrorQueueUnderflow  : eMsgLogLevel = LL_Errors;        break;
    case ET_MsgErrorQueueOverflow   : eMsgLogLevel = LL_Errors;        break;

    default                         : ASSERT(FALSE);                   break;
  }
  
  if(m_eLoggingLevel >= eMsgLogLevel)
    return TRUE;
  else
    return FALSE;
}

STDMETHODIMP CLogger::SetLoggingLevel(byte bLevel)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  m_eLoggingLevel = (eLoggingLevel)bLevel;

	return S_OK;
}

STDMETHODIMP CLogger::GetLLDetails(BSTR arrLevelName[], long arrLevelID[])
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  arrLevelName[0] = SysAllocString(CComBSTR("None"));
  arrLevelID[0]   = LL_None;

  arrLevelName[1] = SysAllocString(CComBSTR("Errors only"));
  arrLevelID[1]   = LL_Errors;

  arrLevelName[2] = SysAllocString(CComBSTR("Errors + activity"));
  arrLevelID[2]   = LL_Activity;

  arrLevelName[3] = SysAllocString(CComBSTR("Errors + activity + UI"));
  arrLevelID[3]   = LL_UserInterface;

  arrLevelName[4] = SysAllocString(CComBSTR("All"));
  arrLevelID[4]   = LL_All;

	return S_OK;
}
