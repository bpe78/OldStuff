// Settings.h : Declaration of the CSettings

#ifndef __SETTINGS_H_
#define __SETTINGS_H_

#include "resource.h"       // main symbols

#define REG_ENTRY_BUFFER_LENGTH 128

// Registry Key settings
#define REG_APP_SUBKEY "Software\\COM_Server"

#define REG_KEY_CLIENT_THREADS_START_NUMBER     "NumberOfClientThreadsStart"
#define REG_KEY_SERVER_THREADS_START_NUMBER     "NumberOfServerThreadsStart"
#define REG_KEY_CLIENT_THREADS_STOP_NUMBER      "NumberOfClientThreadsStop"
#define REG_KEY_SERVER_THREADS_STOP_NUMBER      "NumberOfServerThreadsStop"
#define REG_KEY_CLIENT_THREADS_SLEEPTIME        "ClientsSleepTime"
#define REG_KEY_SERVER_THREADS_SLEEPTIME        "ServersSleepTime"
#define REG_KEY_QUEUE_MIN_MESSAGES              "QueueMinMessages"
#define REG_KEY_QUEUE_MAX_MESSAGES              "QueueMaxMessages"
#define REG_KEY_LOG_LEVEL                       "Log_Level"
#define REG_KEY_LOG_FILENAME                    "Log_Filename"


/////////////////////////////////////////////////////////////////////////////
// CSettings
// - performs loading/saving of application settings from/into the registry

class ATL_NO_VTABLE CSettings : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CSettings, &CLSID_Settings>,
	public ISettings
{
public:
	CSettings()
	{
    m_hKey = NULL;
    m_bCreated = FALSE;

    RegistryOpen(TRUE);
  }
  ~CSettings()
  {
    RegistryClose();
  }

DECLARE_REGISTRY_RESOURCEID(IDR_SETTINGS)
DECLARE_NOT_AGGREGATABLE(CSettings)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CSettings)
	COM_INTERFACE_ENTRY(ISettings)
END_COM_MAP()

// ISettings
public:
  STDMETHOD(GetClientThreadsStartNumber)(/*[out] */long *lpValue);
  STDMETHOD(SetClientThreadsStartNumber)(/*[in]*/ long lValue);

  STDMETHOD(GetClientThreadsStopNumber)(/*[out] */long *lpValue);
  STDMETHOD(SetClientThreadsStopNumber)(/*[in]*/ long lValue);
  
  STDMETHOD(GetServerThreadsStartNumber)(/*[out]*/ long *lpValue);
  STDMETHOD(SetServerThreadsStartNumber)(/*[in]*/ long lValue);

  STDMETHOD(GetServerThreadsStopNumber)(/*[out]*/ long *lpValue);
  STDMETHOD(SetServerThreadsStopNumber)(/*[in]*/ long lValue);

  STDMETHOD(GetClientThreadsSleepTime)(/*[out]*/ long *lpValue);
  STDMETHOD(SetClientThreadsSleepTime)(/*[in]*/ long lValue);

  STDMETHOD(GetServerThreadsSleepTime)(/*[out]*/ long *lpValue);
  STDMETHOD(SetServerThreadsSleepTime)(/*[in]*/ long lValue);

  STDMETHOD(GetQueueMinMessages)(/*[out]*/ long *lpValue);
  STDMETHOD(SetQueueMinMessages)(/*[in]*/ long lValue);

  STDMETHOD(GetQueueMaxMessages)(/*[out]*/ long *lpValue);
  STDMETHOD(SetQueueMaxMessages)(/*[in]*/ long lValue);
  
  STDMETHOD(GetLogLevel)(/*[out]*/ long *lpValue);
  STDMETHOD(SetLogLevel)(/*[in]*/ long lValue);

  STDMETHOD(GetLogFilename)(/*[out]*/ BSTR *bstrFilename);
  STDMETHOD(SetLogFilename)(/*[in]*/ BSTR bstrFilename);
  
  
protected:
  // open main registry key
  // bForceCreate - if key not present, try to create it
  void RegistryOpen(boolean bForceCreate);
  // close registry key
  void RegistryClose();

  // retrieve values from specified keyname
  // strValueName - key name
  // lValue       - object to store retrieved value
  boolean GetValueL(CString strValueName, long *lValue);
  // store value in registry into specified keyname
  // strValueName - key name
  // lValue       - value to be stores
  boolean SetValueL(CString strValueName, long lValue);
  
  // retrieve values from specified keyname
  // strValueName - key name
  // strValue     - object to store retrieved value
  boolean GetValueS(CString strValueName, CString *strValue);
  // store value in registry into specified keyname
  // strValueName - key name
  // strValue     - value to be stores
  boolean SetValueS(CString strValueName, CString strValue);
  
  // error management routine
  // lErrorMessage - system error to be displayed
  void DisplayError(LONG lErrorMessage);

private:
  HKEY m_hKey;
  BOOL m_bCreated;
};

#endif //__SETTINGS_H_
