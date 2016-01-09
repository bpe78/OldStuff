#if !defined(AFX_SERVERTHREAD_H__796321E0_A211_4B34_9FF8_49858806592F__INCLUDED_)
#define AFX_SERVERTHREAD_H__796321E0_A211_4B34_9FF8_49858806592F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CServerThread thread
// - pops messages from the queue

class CServerThread : public CWinThread
{
	DECLARE_DYNCREATE(CServerThread)
protected:
	CServerThread();           // protected constructor used by dynamic creation

// Attributes
public:

// Operations
public:
  // update configuration, called by thread creator
  void UpdateConfiguration(IMessageQueue* pIMessageQueue, long lInterval);
  // creator is signaling that we should terminate
  void SignalTerminate();
  
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CServerThread)
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
  virtual int Run();
  //}}AFX_VIRTUAL

// Implementation
protected:
	virtual ~CServerThread();

	// Generated message map functions
	//{{AFX_MSG(CServerThread)
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()

private:
  CComPtr<IMessageQueue>  m_spMessageQueue;     // message queue interface 
  CComPtr<ILogger>        m_spLogger;           // logger interface
  long                    m_lInterval;          // interval between message pop
  boolean                 m_bSignalTerminate;   // TRUE = terminate thread
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SERVERTHREAD_H__796321E0_A211_4B34_9FF8_49858806592F__INCLUDED_)
