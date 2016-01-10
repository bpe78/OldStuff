#include "stdafx.h"
#include "X1.h"
#include "X1Doc.h"
#include "X1View1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CX1View1

IMPLEMENT_DYNCREATE(CX1View1, CView)

CX1View1::CX1View1()
{
}

CX1View1::~CX1View1()
{
}


BEGIN_MESSAGE_MAP(CX1View1, CView)
	//{{AFX_MSG_MAP(CX1View1)
		// NOTE - the ClassWizard will add and remove mapping macros here.
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CX1View1 drawing

void CX1View1::OnDraw(CDC* pDC)
{
	CDocument* pDoc = GetDocument();
	// TODO: add draw code here
  pDC->MoveTo(100, 100);
  pDC->LineTo(100, 200);
}

/////////////////////////////////////////////////////////////////////////////
// CX1View1 diagnostics

#ifdef _DEBUG
void CX1View1::AssertValid() const
{
	CView::AssertValid();
}

void CX1View1::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CX1View1 message handlers
