// ServerUI.h : main header file for the SERVERUI application
//

#if !defined(AFX_SERVERUI_H__13C4DC65_88D5_49CF_B90D_A654C7F31D13__INCLUDED_)
#define AFX_SERVERUI_H__13C4DC65_88D5_49CF_B90D_A654C7F31D13__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CServerUIApp:
// See ServerUI.cpp for the implementation of this class
//

class CServerUIApp : public CWinApp
{
public:
	CServerUIApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CServerUIApp)
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CServerUIApp)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SERVERUI_H__13C4DC65_88D5_49CF_B90D_A654C7F31D13__INCLUDED_)
