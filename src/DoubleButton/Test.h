#if !defined(AFX_TEST_H__8FA20F25_C3B9_11D6_878A_000021F57B37__INCLUDED_)
#define AFX_TEST_H__8FA20F25_C3B9_11D6_878A_000021F57B37__INCLUDED_

/////////////////////////////////////////////////////////////////////////////
// CTest dialog

class CTest : public CDialog
{
// Construction
public:
	CTest(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CTest)
	enum { IDD = IDD_ABOUTBOX };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTest)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CTest)
	virtual BOOL OnInitDialog();
	afx_msg void OnDestroy();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
  CDoubleButton *pDblButton;
  CEdit pEditButton;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TEST_H__8FA20F25_C3B9_11D6_878A_000021F57B37__INCLUDED_)
