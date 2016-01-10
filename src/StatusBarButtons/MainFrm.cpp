// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "X3.h"

#include "MainFrm.h"

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
	ON_WM_SIZE()
	ON_COMMAND(ID_CALCUL, OnCalcul)
	ON_COMMAND(ID_EXPORT_ADV, OnExportAdv)
	ON_COMMAND(ID_EXPORT_DXF, OnExportDxf)
	ON_COMMAND(ID_LAST, OnLast)
	ON_COMMAND(ID_LIGHT, OnLight)
	ON_COMMAND(ID_NEXT, OnNext)
	ON_COMMAND(ID_PRINT, OnPrint)
	ON_COMMAND(ID_VISION, OnVision)
	ON_COMMAND(ID_CALCUL2, OnCalcul2)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
  ID_INDICATOR_BUTTONS
};


/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
  m_bCalculOK = FALSE;
  m_bErrors = TRUE;
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if(CFrameWnd::OnCreate(lpCreateStruct) == -1)  return -1;

  if(CreateStatusBar() == -1) return -1;
  if(CreateStatusBarButtons() == -1) return -1;

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

int CMainFrame::CreateStatusBar()
{
	if (!m_wndStatusBar.Create(this) ||	!m_wndStatusBar.SetIndicators(indicators, sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}
  m_wndStatusBar.SendMessage(SB_SETMINHEIGHT, 22, 0);

  return 0;
}


int CMainFrame::CreateStatusBarButtons()
{
	if(!m_wndToolBar.CreateEx(&m_wndStatusBar, WS_CHILD | WS_VISIBLE | CBRS_SIZE_DYNAMIC | CBRS_TOP	| CBRS_TOOLTIPS | CBRS_FLYBY) ||
     !m_wndToolBar.LoadToolBar(IDR_STATUSBARBUTTONS))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

#ifdef _DEBUG
  CString s;
  s.LoadString(ID_INDICATOR_BUTTONS);
  ASSERT(s.GetLength() >= (INT)(NB_BUTTONS*8.75));
#endif

  UINT nID = 0, nStyle = 0;
  int iImage = 0;

  int nButtons = m_wndToolBar.GetToolBarCtrl().GetButtonCount();
  for(int i=0; i<nButtons; i++)
  {
    m_wndToolBar.GetButtonInfo(i, nID, nStyle, iImage);

    if(i<NB_BUTTONS)  nStyle &= ~TBBS_HIDDEN;
    else              nStyle |= TBBS_HIDDEN;
    m_wndToolBar.SetButtonInfo(i, nID, nStyle, iImage);
  }
  UpdateCalculButton();
  UpdateLightButton();

  return 0;
}

void CMainFrame::UpdateCalculButton()
{
  UINT nID = 0, nStyle = 0;
  int iImage = 0;
  int iIndex = m_wndToolBar.CommandToIndex(ID_CALCUL);

  if(m_bCalculOK)
  {
    m_wndToolBar.GetButtonInfo(iIndex, nID, nStyle, iImage);
    iImage = IMAGE_CALCUL1;
    m_wndToolBar.SetButtonInfo(iIndex, nID, nStyle, iImage);
  }
  else
  {
    m_wndToolBar.GetButtonInfo(iIndex, nID, nStyle, iImage);
    iImage = IMAGE_CALCUL0;
    m_wndToolBar.SetButtonInfo(iIndex, nID, nStyle, iImage);
  }
}

void CMainFrame::UpdateLightButton()
{
  UINT nID = 0, nStyle = 0;
  int iImage = 0;
  int iIndex = m_wndToolBar.CommandToIndex(ID_LIGHT);

  if(m_bErrors)
  {
    m_wndToolBar.GetButtonInfo(iIndex, nID, nStyle, iImage);
    iImage = IMAGE_LIGHT_ON;
    m_wndToolBar.SetButtonInfo(iIndex, nID, nStyle, iImage);
  }
  else
  {
    m_wndToolBar.GetButtonInfo(iIndex, nID, nStyle, iImage);
    iImage = IMAGE_LIGHT_OFF;
    m_wndToolBar.SetButtonInfo(iIndex, nID, nStyle, iImage);
  }
}


void CMainFrame::OnSize(UINT nType, int cx, int cy) 
{
	CFrameWnd::OnSize(nType, cx, cy);
	
  CStatusBarCtrl &pSBCtrl = m_wndStatusBar.GetStatusBarCtrl();
  if(::IsWindow(pSBCtrl.GetSafeHwnd()))
  {
    int arrParts[2]={0};
    pSBCtrl.GetParts(2, arrParts);
    m_wndToolBar.MoveWindow(CRect(arrParts[0], 0, arrParts[1], 22));

  }
}

void CMainFrame::OnCalcul() 
{
  m_bCalculOK = !m_bCalculOK;
  UpdateCalculButton();
}

void CMainFrame::OnExportAdv() 
{
}

void CMainFrame::OnExportDxf() 
{
}

void CMainFrame::OnLast() 
{
}

void CMainFrame::OnLight() 
{
  m_bErrors = !m_bErrors;
  UpdateLightButton();
}

void CMainFrame::OnNext() 
{
}

void CMainFrame::OnPrint() 
{
}

void CMainFrame::OnVision() 
{
}

void CMainFrame::OnCalcul2() 
{
	// TODO: Add your command handler code here
	
}
