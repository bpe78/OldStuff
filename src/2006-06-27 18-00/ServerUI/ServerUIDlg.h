// ServerUIDlg.h : header file
//

#if !defined(AFX_SERVERUIDLG_H__7AAD7DC1_E6C3_496E_BFBE_E5B653214ABA__INCLUDED_)
#define AFX_SERVERUIDLG_H__7AAD7DC1_E6C3_496E_BFBE_E5B653214ABA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CServerUIDlg dialog

#define MSG_ADD_STRING_TO_LIST (WM_USER+1)


class CServerUIDlg : public CDialog
{
// Construction
public:
	CServerUIDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CServerUIDlg)
	enum { IDD = IDD_SERVERUI_DIALOG };
	CListBox m_lbQueue;
	long m_nNbClientThreadsStart;
	long m_nNbServerThreadsStart;
  long m_nNbClientThreadsStop;
  long m_nNbServerThreadsStop;
  long m_nSleepTimeClients;
	long m_nSleepTimeServers;
	long m_nQueueMinMessages;
	long m_nQueueMaxMessages;
	long	m_lClientsRunning;
	long	m_lServersRunning;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CServerUIDlg)
	public:
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CServerUIDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClientsStart();
	afx_msg void OnServersStart();
  afx_msg void OnClientsStop();
  afx_msg void OnServersStop();
  afx_msg void OnSetSleepClient();
  afx_msg void OnSetSleepServer();
  afx_msg void OnQueueMin();
  afx_msg void OnQueueMax();
  afx_msg void OnDisplayClear();
  afx_msg void OnDisplayStop();
  afx_msg void OnLogOptions();
  afx_msg void OnLogDisplay();
  afx_msg void OnBtnApplicationExit();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

protected:
  // HELPER functions
  // Interface getters
  boolean IsSettingsAvailable();                // get ISettings component
  boolean IsLoggerAvailable();                  // get ILogger component
  boolean IsMessageQueueAvailable();            // get IMessageQueue component
  // Queue
  void ClearMessageQueue();
  void StopMessageQueue();
  // Registry settings
  void LoadSettings();                          // load settings from registry
  void SaveSettings();                          // save settings into registry
  // transport options from UI to server
  void UpdateServerConfiguration(eConfiguration eConfig);

private:
  CComPtr<IMessageQueue>  m_spMessageQueue;     // pointer to message queue interface
  CComPtr<ILogger>        m_spLogger;           // pointer to logger interface
  CComPtr<ISettings>      m_spSettings;         // pointer to settings interface
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SERVERUIDLG_H__7AAD7DC1_E6C3_496E_BFBE_E5B653214ABA__INCLUDED_)
