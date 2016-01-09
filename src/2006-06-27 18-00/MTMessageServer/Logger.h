// Logger.h : Declaration of the CLogger

#ifndef __LOGGER_H_
#define __LOGGER_H_

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CLogger
// - performs logging of messages from any application
// - displays the log file in notepad
// - can support different levels of logging (None/Errors/Activity/UI/All)

class ATL_NO_VTABLE CLogger : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CLogger, &CLSID_Logger>,
	public ILogger
{
public:
	CLogger();

DECLARE_REGISTRY_RESOURCEID(IDR_LOGGER)
DECLARE_NOT_AGGREGATABLE(CLogger)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CLogger)
	COM_INTERFACE_ENTRY(ILogger)
END_COM_MAP()

// ILogger
public:
  STDMETHOD(DisplayLog)();
  STDMETHOD(AddLogEntry)(/*[in]*/ byte bType, /*[in]*/ long lThreadID, /*[in]*/ long lNumber, /*[in]*/ BSTR bstrDescription);
  STDMETHOD(GetLLDetails)(/*[out]*/ BSTR arrLevelName[5], /*[out]*/ long arrLevelID[5]);
	STDMETHOD(SetLoggingLevel)(/*[in]*/ byte bLevel);

private:
	boolean FilterMessage(eEventType eType);  // accept/reject messages based on current log level
  char*   GetLogFilename();                 // return log filename (from registry of default)

private:
  eLoggingLevel m_eLoggingLevel;    // active logging level
};

#endif //__LOGGER_H_
