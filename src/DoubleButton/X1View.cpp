// X1View.cpp : implementation of the CX1View class
//

#include "stdafx.h"
#include "X1.h"

#include "X1Doc.h"
#include "X1View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CX1View

IMPLEMENT_DYNCREATE(CX1View, CView)

BEGIN_MESSAGE_MAP(CX1View, CView)
	//{{AFX_MSG_MAP(CX1View)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CX1View construction/destruction

CX1View::CX1View()
{
	// TODO: add construction code here

}

CX1View::~CX1View()
{
}

BOOL CX1View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CX1View drawing

void CX1View::OnDraw(CDC* pDC)
{
	CX1Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CX1View diagnostics

#ifdef _DEBUG
void CX1View::AssertValid() const
{
	CView::AssertValid();
}

void CX1View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CX1Doc* CX1View::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CX1Doc)));
	return (CX1Doc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CX1View message handlers
