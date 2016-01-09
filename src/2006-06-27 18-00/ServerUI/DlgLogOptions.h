#if !defined(AFX_DLGLOGOPTIONS_H__E613EF61_4CE6_4506_B64C_B71FBB06A776__INCLUDED_)
#define AFX_DLGLOGOPTIONS_H__E613EF61_4CE6_4506_B64C_B71FBB06A776__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CDlgLogOptions dialog

class CDlgLogOptions : public CDialog
{
// Construction
public:
	CDlgLogOptions(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CDlgLogOptions)
	enum { IDD = IDD_LOG_OPTIONS };
	CEdit	m_ctrlFilename;
	CComboBox	m_ctrlLevels;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlgLogOptions)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CDlgLogOptions)
	afx_msg void OnLogBrowse();
	virtual void OnOK();
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
  std::vector<long> m_vecValues;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLGLOGOPTIONS_H__E613EF61_4CE6_4506_B64C_B71FBB06A776__INCLUDED_)
