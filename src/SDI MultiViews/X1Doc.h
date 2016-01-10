// X1Doc.h : interface of the CX1Doc class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_X1DOC_H__115DACAB_0D9F_11D7_87F6_000021F57B37__INCLUDED_)
#define AFX_X1DOC_H__115DACAB_0D9F_11D7_87F6_000021F57B37__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CX1Doc : public CDocument
{
protected: // create from serialization only
	CX1Doc();
	DECLARE_DYNCREATE(CX1Doc)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX1Doc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CX1Doc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CX1Doc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X1DOC_H__115DACAB_0D9F_11D7_87F6_000021F57B37__INCLUDED_)
