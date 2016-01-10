// MainFrm.h : interface of the CMainFrame class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_MAINFRM_H__A7D933E5_BB50_43AE_971C_5746259B48A4__INCLUDED_)
#define AFX_MAINFRM_H__A7D933E5_BB50_43AE_971C_5746259B48A4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CMainFrame : public CFrameWnd
{
#define NB_BUTTONS 8  // number of buttons visible
enum ButtonImages {IMAGE_CALCUL0, IMAGE_LIGHT_OFF, IMAGE_VISION, IMAGE_PRINT, IMAGE_EXPORT_DXF, IMAGE_EXPORT_ADV, IMAGE_LAST, IMAGE_NEXT, IMAGE_CALCUL1, IMAGE_LIGHT_ON};
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainFrame)
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	CStatusBar  m_wndStatusBar;
	CToolBar    m_wndToolBar;

  BOOL m_bCalculOK;
  BOOL m_bErrors;

  int CreateStatusBar();
  int CreateStatusBarButtons();
  void UpdateCalculButton();
  void UpdateLightButton();

// Generated message map functions
protected:
	//{{AFX_MSG(CMainFrame)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnCalcul();
	afx_msg void OnExportAdv();
	afx_msg void OnExportDxf();
	afx_msg void OnLast();
	afx_msg void OnLight();
	afx_msg void OnNext();
	afx_msg void OnPrint();
	afx_msg void OnVision();
	afx_msg void OnCalcul2();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAINFRM_H__A7D933E5_BB50_43AE_971C_5746259B48A4__INCLUDED_)
