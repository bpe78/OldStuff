// Test.cpp : implementation file
//

#include "stdafx.h"
#include "X1.h"
#include "Test.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTest dialog


CTest::CTest(CWnd* pParent /*=NULL*/)
	: CDialog(CTest::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTest)
	//}}AFX_DATA_INIT
}


void CTest::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTest)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CTest, CDialog)
	//{{AFX_MSG_MAP(CTest)
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTest message handlers

BOOL CTest::OnInitDialog() 
{
	CDialog::OnInitDialog();
    
	// Window settings
  SetWindowText("Test");
  MoveWindow(0, 0, 800, 300, TRUE);
  CenterWindow(NULL);
  // Buttons
  pDblButton = new CDoubleButton(this, 50, 20, 200, 50, "Masa = ", "kg");

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CTest::OnDestroy() 
{
	CDialog::OnDestroy();
	
  delete pDblButton;
}
