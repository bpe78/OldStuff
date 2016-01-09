// Settings.cpp : Implementation of CSettings
#include "stdafx.h"
#include "MTMessageServer.h"
#include "Settings.h"

/////////////////////////////////////////////////////////////////////////////
// CSettings


void CSettings::RegistryOpen(boolean bForceCreate)
{
  DWORD dwDisposition = 0;
  
  // open or create registry key
  LONG lResult = RegOpenKeyEx(HKEY_CURRENT_USER, REG_APP_SUBKEY, 0, KEY_READ | KEY_WRITE, &m_hKey);
  if(ERROR_SUCCESS == lResult)
  {
    return;
  }
  
  // try to create key, used for first-time creation of registry entries
  if(bForceCreate)
  {
    lResult = RegCreateKeyEx(HKEY_CURRENT_USER, REG_APP_SUBKEY, 0, "", REG_OPTION_NON_VOLATILE, KEY_READ | KEY_WRITE, NULL, &m_hKey, &dwDisposition);
    if(ERROR_SUCCESS == lResult)
    {
      m_bCreated = TRUE;
      return;
    }
  }
  
  // error
  DisplayError(lResult);
  
  // reset value to return
  ZeroMemory(m_hKey, sizeof(m_hKey));
}

void CSettings::RegistryClose()
{
  if(m_hKey == NULL)
  {
    ASSERT(FALSE);
    return;
  }
  
  RegCloseKey(m_hKey);
}


boolean CSettings::GetValueL(CString strValueName, long *lpValue)
{
  if(m_hKey == NULL)
  {
    ASSERT(FALSE);
    return FALSE;
  }

  // all values are saved in registry as strings
  unsigned char pData[REG_ENTRY_BUFFER_LENGTH] = {0};
  DWORD dwType = REG_SZ;
  DWORD dwSize = REG_ENTRY_BUFFER_LENGTH;
  LONG lResult = RegQueryValueEx(m_hKey, strValueName, 0, &dwType, pData, &dwSize);

  if(lResult != ERROR_SUCCESS)
  {
    SetValueL(strValueName, 0);   // create entry if not exist
    *lpValue = 0;                 // reset returned value
    return FALSE;
  }

  int TmpValue = 0;
  sscanf((char*)pData, "%d", &TmpValue);
  *lpValue = TmpValue;

  return TRUE;
}


boolean CSettings::SetValueL(CString strValueName, long lValue)
{
  if(m_hKey == NULL)
  {
    ASSERT(FALSE);
    return FALSE;
  }

  // all values are saved in registry as strings
  char szBuffer[REG_ENTRY_BUFFER_LENGTH] = {0};
  sprintf(szBuffer, "%d", lValue);

  LONG lResult = RegSetValueEx(m_hKey, strValueName, 0, REG_SZ, (unsigned char *)szBuffer, REG_ENTRY_BUFFER_LENGTH);

  if(lResult != ERROR_SUCCESS)
  {
    DisplayError(lResult);
    return FALSE;
  }

  return TRUE;
}


boolean CSettings::GetValueS(CString strValueName, CString *strValue)
{
  if(m_hKey == NULL)
  {
    ASSERT(FALSE);
    return FALSE;
  }
  
  // all values are saved in registry as strings
  unsigned char pData[REG_ENTRY_BUFFER_LENGTH] = {0};
  DWORD dwType = REG_SZ;
  DWORD dwSize = REG_ENTRY_BUFFER_LENGTH;
  LONG lResult = RegQueryValueEx(m_hKey, strValueName, 0, &dwType, pData, &dwSize);

  if(lResult != ERROR_SUCCESS)
  {
    SetValueS(*strValueName, "");     // create entry if not exist
    *strValue = "";                   // reset returned value
    return FALSE;
  }

  *strValue = (char*)pData;
  
  return TRUE;
}

boolean CSettings::SetValueS(CString strValueName, CString strValue)
{
  if(m_hKey == NULL)
  {
    ASSERT(FALSE);
    return FALSE;
  }
  
  // all values are saved in registry as strings
  char szBuffer[REG_ENTRY_BUFFER_LENGTH] = {0};
  sprintf(szBuffer, "%s", strValue);
  
  LONG lResult = RegSetValueEx(m_hKey, strValueName, 0, REG_SZ, (unsigned char *)szBuffer, REG_ENTRY_BUFFER_LENGTH);
  
  if(lResult != ERROR_SUCCESS)
  {
    DisplayError(lResult);
    return FALSE;
  }
  
  return TRUE;
}


void CSettings::DisplayError(LONG lErrorMessage)
{
#define ERROR_BUFFER_LENGTH 512

  ASSERT(lErrorMessage != ERROR_SUCCESS);

  char szBuffer[ERROR_BUFFER_LENGTH] = {0};
  FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, NULL, lErrorMessage, 0, szBuffer, ERROR_BUFFER_LENGTH, NULL);
  AfxMessageBox(szBuffer);
}

////////////////////////////////////////
// ISetting interface implementation ///
////////////////////////////////////////

STDMETHODIMP CSettings::GetClientThreadsStartNumber(long *lpValue)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState());

  if(GetValueL(REG_KEY_CLIENT_THREADS_START_NUMBER, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetClientThreadsStartNumber(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  SetValueL(REG_KEY_CLIENT_THREADS_START_NUMBER, lValue);

  return S_OK;
}

STDMETHODIMP CSettings::GetClientThreadsStopNumber(long *lpValue)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState());
  
  if(GetValueL(REG_KEY_CLIENT_THREADS_STOP_NUMBER, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetClientThreadsStopNumber(long lValue)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())
    
    SetValueL(REG_KEY_CLIENT_THREADS_STOP_NUMBER, lValue);
  
  return S_OK;
}

STDMETHODIMP CSettings::GetServerThreadsStartNumber(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  if(GetValueL(REG_KEY_SERVER_THREADS_START_NUMBER, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetServerThreadsStartNumber(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  SetValueL(REG_KEY_SERVER_THREADS_START_NUMBER, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetServerThreadsStopNumber(long *lpValue)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())
    
  if(GetValueL(REG_KEY_SERVER_THREADS_STOP_NUMBER, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetServerThreadsStopNumber(long lValue)
{
  AFX_MANAGE_STATE(AfxGetStaticModuleState())
    
  SetValueL(REG_KEY_SERVER_THREADS_STOP_NUMBER, lValue);
  
  return S_OK;
}

STDMETHODIMP CSettings::GetClientThreadsSleepTime(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	if(GetValueL(REG_KEY_CLIENT_THREADS_SLEEPTIME, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetClientThreadsSleepTime(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	SetValueL(REG_KEY_CLIENT_THREADS_SLEEPTIME, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetServerThreadsSleepTime(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  if(GetValueL(REG_KEY_SERVER_THREADS_SLEEPTIME, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetServerThreadsSleepTime(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  SetValueL(REG_KEY_SERVER_THREADS_SLEEPTIME, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetQueueMinMessages(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	if(GetValueL(REG_KEY_QUEUE_MIN_MESSAGES, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetQueueMinMessages(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	SetValueL(REG_KEY_QUEUE_MIN_MESSAGES, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetQueueMaxMessages(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  if(GetValueL(REG_KEY_QUEUE_MAX_MESSAGES, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetQueueMaxMessages(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	SetValueL(REG_KEY_QUEUE_MAX_MESSAGES, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetLogLevel(long *lpValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	if(GetValueL(REG_KEY_LOG_LEVEL, lpValue))
    return S_OK;
  else
    return S_FALSE;
}

STDMETHODIMP CSettings::SetLogLevel(long lValue)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

	SetValueL(REG_KEY_LOG_LEVEL, lValue);

	return S_OK;
}

STDMETHODIMP CSettings::GetLogFilename(BSTR *bstrFilename)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  CString sTmp;
  GetValueS(REG_KEY_LOG_FILENAME, &sTmp);
  *bstrFilename = SysAllocString(CComBSTR(sTmp));

  return S_OK;
}

STDMETHODIMP CSettings::SetLogFilename(BSTR bstrFilename)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState())

  CString sTmp = CString(bstrFilename);
  SetValueS(REG_KEY_LOG_FILENAME, sTmp);

	return S_OK;
}
