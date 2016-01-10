// X3View.cpp : implementation of the CX3View class
//

#include "stdafx.h"
#include "X3.h"

#include "X3Doc.h"
#include "X3View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CX3View

IMPLEMENT_DYNCREATE(CX3View, CView)

BEGIN_MESSAGE_MAP(CX3View, CView)
	//{{AFX_MSG_MAP(CX3View)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CX3View construction/destruction

CX3View::CX3View()
{
	// TODO: add construction code here

}

CX3View::~CX3View()
{
}

BOOL CX3View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CX3View drawing

void CX3View::OnDraw(CDC* pDC)
{
	CX3Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CX3View diagnostics

#ifdef _DEBUG
void CX3View::AssertValid() const
{
	CView::AssertValid();
}

void CX3View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CX3Doc* CX3View::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CX3Doc)));
	return (CX3Doc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CX3View message handlers
