#if !defined(AFX_CLIENTTHREAD_H__09463287_29DB_4C09_B0AD_4A783A53998F__INCLUDED_)
#define AFX_CLIENTTHREAD_H__09463287_29DB_4C09_B0AD_4A783A53998F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// ClientThread.h : header file
//
#include "MTMessageServer.h"

/////////////////////////////////////////////////////////////////////////////
// CClientThread thread
// - pushes messages into the message queue

class CClientThread : public CWinThread
{
	DECLARE_DYNCREATE(CClientThread)
protected:
	CClientThread();           // protected constructor used by dynamic creation

// Attributes
public:

// Operations
public:
  // update configuration, called by thread creator
  void UpdateConfiguration(IMessageQueue* pIMessageQueue, long lInterval);
  // terminate thread, called by creator
  void SignalTerminate();
  
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CClientThread)
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	virtual int Run();
	//}}AFX_VIRTUAL

// Implementation
protected:
	virtual ~CClientThread();

	// Generated message map functions
	//{{AFX_MSG(CClientThread)
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()

private:
  CComPtr<IMessageQueue>  m_spMessageQueue;   // pointer to message queue interface
  CComPtr<ILogger>        m_spLogger;         // pointer to logger interface
  long                    m_lInterval;        // interval between 2 consecutive messages
  boolean                 m_bSignalTerminate; // TRUE = terminate thread
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CLIENTTHREAD_H__09463287_29DB_4C09_B0AD_4A783A53998F__INCLUDED_)
