// X3Doc.cpp : implementation of the CX3Doc class
//

#include "stdafx.h"
#include "X3.h"

#include "X3Doc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CX3Doc

IMPLEMENT_DYNCREATE(CX3Doc, CDocument)

BEGIN_MESSAGE_MAP(CX3Doc, CDocument)
	//{{AFX_MSG_MAP(CX3Doc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CX3Doc construction/destruction

CX3Doc::CX3Doc()
{
	// TODO: add one-time construction code here

}

CX3Doc::~CX3Doc()
{
}

BOOL CX3Doc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CX3Doc serialization

void CX3Doc::Serialize(CArchive& ar)
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
// CX3Doc diagnostics

#ifdef _DEBUG
void CX3Doc::AssertValid() const
{
	CDocument::AssertValid();
}

void CX3Doc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CX3Doc commands
