// ServerUI.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "ServerUI.h"
#include "ServerUIDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CServerUIApp

BEGIN_MESSAGE_MAP(CServerUIApp, CWinApp)
	//{{AFX_MSG_MAP(CServerUIApp)
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CServerUIApp construction

CServerUIApp::CServerUIApp()
{
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CServerUIApp object

CServerUIApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CServerUIApp initialization

BOOL CServerUIApp::InitInstance()
{
	// Standard initialization

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

  CoInitialize(NULL);

	CServerUIDlg dlg;
	m_pMainWnd = &dlg;
	dlg.DoModal();

	return FALSE;
}

int CServerUIApp::ExitInstance() 
{
  CoUninitialize();
	
	return CWinApp::ExitInstance();
}
