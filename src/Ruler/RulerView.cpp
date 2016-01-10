// RulerView.cpp : implementation of the CRulerView class
//

#include "stdafx.h"
#include "Ruler.h"

#include "RulerDoc.h"
#include "RulerView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CRulerView

IMPLEMENT_DYNCREATE(CRulerView, CView)

BEGIN_MESSAGE_MAP(CRulerView, CView)
	//{{AFX_MSG_MAP(CRulerView)
	ON_COMMAND(ID_RULER, OnRuler)
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONDOWN()
	ON_WM_SIZE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRulerView construction/destruction

CRulerView::CRulerView()
{
  m_bRulerOn = FALSE;
  m_ptOldPoint = CPoint(-1, -1);
}

CRulerView::~CRulerView()
{
}

BOOL CRulerView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CRulerView drawing

void CRulerView::OnDraw(CDC* pDC)
{
	CRulerDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

  pDC->Rectangle(100, 10, 600, 300);
  if(m_bRulerOn)
    DrawRuler(CPoint(-1, -1), m_ptOldPoint);
}

/////////////////////////////////////////////////////////////////////////////
// CRulerView diagnostics

#ifdef _DEBUG
void CRulerView::AssertValid() const
{
	CView::AssertValid();
}

void CRulerView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CRulerDoc* CRulerView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CRulerDoc)));
	return (CRulerDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CRulerView message handlers

void CRulerView::OnRuler() 
{
  m_bRulerOn = !m_bRulerOn;
  DrawRuler(m_ptOldPoint, CPoint(-1, -1));
}

void CRulerView::OnMouseMove(UINT nFlags, CPoint point) 
{
  if(m_bRulerOn && (nFlags & MK_LBUTTON))
  {
    DrawRuler(m_ptOldPoint, point);
  }
	
	CView::OnMouseMove(nFlags, point);
}


void CRulerView::DrawRuler(CPoint &ptOldPoint, CPoint &ptNewPoint, bool bSetPoint)
{
  CRect rect;
  GetClientRect(&rect);

  CClientDC dc(this);
  dc.SetROP2(R2_NOT);
  // erase old point
  if(rect.PtInRect(ptOldPoint))
  {
    dc.MoveTo(ptOldPoint.x, rect.top);
    dc.LineTo(ptOldPoint.x, rect.bottom);
  }
  // draw new point
  if(rect.PtInRect(ptNewPoint))
  {
    dc.MoveTo(ptNewPoint.x, rect.top);
    dc.LineTo(ptNewPoint.x, rect.bottom);
    DWORD colorText = GetSysColor(COLOR_INFOTEXT);
    DWORD colorBack = GetSysColor(COLOR_INFOBK);
    CRect rectToolTip(0, 0, 100, 30);
    CString s;
    s.Format("X = %d\nY = %d", ptNewPoint.x, ptNewPoint.y);
    dc.SetTextColor(GetSysColor(COLOR_INFOTEXT));
    dc.DrawText(s, &rectToolTip, DT_NOCLIP | DT_LEFT | DT_TOP | DT_EXPANDTABS);

  }
  if(bSetPoint)
    ptOldPoint = ptNewPoint;
}

void CRulerView::OnLButtonDown(UINT nFlags, CPoint point) 
{
  if(m_bRulerOn)
  {
    DrawRuler(m_ptOldPoint, point);
  }
	
	CView::OnLButtonDown(nFlags, point);
}

void CRulerView::OnSize(UINT nType, int cx, int cy) 
{
  CRect r, r1;
  GetClientRect(&r);
	CView::OnSize(nType, cx, cy);
  GetClientRect(&r1);
}
