// X1Doc.cpp : implementation of the CX1Doc class
//

#include "stdafx.h"
#include "X1.h"

#include "X1Doc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CX1Doc

IMPLEMENT_DYNCREATE(CX1Doc, CDocument)

BEGIN_MESSAGE_MAP(CX1Doc, CDocument)
	//{{AFX_MSG_MAP(CX1Doc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CX1Doc construction/destruction

CX1Doc::CX1Doc()
{
	// TODO: add one-time construction code here

}

CX1Doc::~CX1Doc()
{
}

BOOL CX1Doc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CX1Doc serialization

void CX1Doc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CX1Doc diagnostics

#ifdef _DEBUG
void CX1Doc::AssertValid() const
{
	CDocument::AssertValid();
}

void CX1Doc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CX1Doc commands
