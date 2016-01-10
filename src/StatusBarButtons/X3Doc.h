// X3Doc.h : interface of the CX3Doc class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_X3DOC_H__C091840E_CBA7_4B56_A788_A49A97D8E7B0__INCLUDED_)
#define AFX_X3DOC_H__C091840E_CBA7_4B56_A788_A49A97D8E7B0__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CX3Doc : public CDocument
{
protected: // create from serialization only
	CX3Doc();
	DECLARE_DYNCREATE(CX3Doc)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX3Doc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CX3Doc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CX3Doc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X3DOC_H__C091840E_CBA7_4B56_A788_A49A97D8E7B0__INCLUDED_)
