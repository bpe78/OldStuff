// MessageQueue.h : Declaration of the CMessageQueue

#ifndef __MESSAGEQUEUE_H_
#define __MESSAGEQUEUE_H_

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CMessageQueue
// - manages the messages in the queue
// - creates/terminates client/server threads
// - performs logging of all activity

class ATL_NO_VTABLE CMessageQueue : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMessageQueue, &CLSID_MessageQueue>,
	public IMessageQueue
{
public:
	CMessageQueue();
  ~CMessageQueue();

DECLARE_REGISTRY_RESOURCEID(IDR_MESSAGEQUEUE)
DECLARE_NOT_AGGREGATABLE(CMessageQueue)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CMessageQueue)
	COM_INTERFACE_ENTRY(IMessageQueue)
END_COM_MAP()

// IMessageQueue
public:
	STDMETHOD(AddUIListener)(/*[in]*/ long lThreadID);
	STDMETHOD(PushMessage)(/*[in]*/ long lThreadID, /*[out]*/ BSTR bstrMessage);
  STDMETHOD(PopMessage)(/*[out]*/VARIANT *pvtValid, /*[out]*/ BSTR *pbstrMessage);
  STDMETHOD(CanPushMessages)(/*[out]*/ VARIANT *pvtCanPushMessages);
  STDMETHOD(CanPopMessages)(/*[out]*/ VARIANT *pvtCanPopMessages);
  STDMETHOD(UpdateConfiguration)(VARIANT vtInitialize,
                                 /*[in]*/ long m_lNbClientThreadsStart, /*[in]*/ long m_lNbServerThreadsStart,
                                 /*[in]*/ long m_lNbClientThreadsStop, /*[in]*/ long m_lNbServerThreadsStop,
                                 /*[in]*/ long m_lSleepTimeClients, /*[in]*/ long m_lSleepTimeServers,
                                 /*[in]*/ long lMinMessages, /*[in]*/ long lMaxMessages);
  STDMETHOD(ClearQueue)();
  STDMETHOD(StopQueue)();
  STDMETHOD(GetRunningClientThreads)(/*[out]*/ long *plClientsRunning);
  STDMETHOD(GetRunningServerThreads)(/*[out]*/ long *plServersRunning);
  
protected:
  void    StartClientThreads(long lClients);      // start specified number of clients
  void    StopClientThreads(long lClients);       // stop specified number of clients
  void    StartServerThreads(long lServers);      // start specified number of servers
  void    StopServerThreads(long lServers);       // stop specified number of servers
  boolean IsLoggerAvailable();                    // returns TRUE (eventually sets) if m_spLogger is pointing to ILogger interface
  
private:
  long m_UIListener;                              // ThreadID of UI application
  CComPtr<ILogger> m_spLogger;                    // pointer to logger

  long m_lSleepTimeClients;                       // Sleep time between message push (set from interface)
  long m_lSleepTimeServers;                       // Sleep time between message pop  (set from interface)

  long m_lMinMessages;                            // Minimum messages in queue (set from interface)
  long m_lMaxMessages;                            // maximum messages in queue (set from interface)

  std::list<CClientThread*> m_vecClientThreads;   // client threads pool
  std::list<CServerThread*> m_vecServerThreads;   // server threads pool
  
//  std::list<CString> m_listMessages;              // queue of messages
  CLista m_listMessages;                          // queue of messages
  long m_iInternalCounter;                        // message counter (for internal use)
  CRITICAL_SECTION m_cs;
};

#endif //__MESSAGEQUEUE_H_
