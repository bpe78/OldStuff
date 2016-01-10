// Ruler.h : main header file for the RULER application
//

#if !defined(AFX_RULER_H__C5C74A03_82FF_4405_86A0_CFDDA75218D5__INCLUDED_)
#define AFX_RULER_H__C5C74A03_82FF_4405_86A0_CFDDA75218D5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CRulerApp:
// See Ruler.cpp for the implementation of this class
//

class CRulerApp : public CWinApp
{
public:
	CRulerApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRulerApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation
	//{{AFX_MSG(CRulerApp)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RULER_H__C5C74A03_82FF_4405_86A0_CFDDA75218D5__INCLUDED_)
