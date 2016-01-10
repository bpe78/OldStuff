// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "X1.h"

#include "MainFrm.h"
#include "X1View.h"
#include "X1View1.h"

#define PAGE_1 1
#define PAGE_2 2


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_COMMAND(ID_PAGE1, OnPage1)
	ON_COMMAND(ID_PAGE2, OnPage2)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	// TODO: Delete these three lines if you don't want the toolbar to
	//  be dockable
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	EnableDocking(CBRS_ALIGN_ANY);
	DockControlBar(&m_wndToolBar);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMainFrame message handlers

void CMainFrame::SwitchToPage(UINT iPage)
{
  CView *pOldPage = GetActiveView();
  CView *pNewPage = (CView*)GetDlgItem(iPage);
  CCreateContext context;
  context.m_pCurrentDoc = GetActiveDocument();

  if(pNewPage == NULL)  // do not choose the same page
  {
    switch(iPage)
    {
      case PAGE_1 :
      {
        context.m_pNewViewClass = RUNTIME_CLASS(CX1View);
        pNewPage = (CX1View*)CreateView(&context, AFX_IDW_PANE_FIRST);
      } break;
      case PAGE_2 :
      {
        context.m_pNewViewClass = RUNTIME_CLASS(CX1View1);
        pNewPage = (CX1View1*)CreateView(&context, AFX_IDW_PANE_FIRST);
      } break;
    }
    pNewPage->OnInitialUpdate();
  }

  SetActiveView(pNewPage);
  RecalcLayout();
  //SetWindowLong(pNewPage->m_hWnd, GWL_ID, AFX_IDW_PANE_FIRST);
  pNewPage->SetDlgCtrlID(AFX_IDW_PANE_FIRST);

  delete pOldPage;
}



void CMainFrame::OnPage1() 
{
  SwitchToPage(PAGE_1);
}

void CMainFrame::OnPage2() 
{
  SwitchToPage(PAGE_2);
}
