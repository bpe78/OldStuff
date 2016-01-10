// X1View.h : interface of the CX1View class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_X1VIEW_H__8FA20F1D_C3B9_11D6_878A_000021F57B37__INCLUDED_)
#define AFX_X1VIEW_H__8FA20F1D_C3B9_11D6_878A_000021F57B37__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CX1View : public CView
{
protected: // create from serialization only
	CX1View();
	DECLARE_DYNCREATE(CX1View)

// Attributes
public:
	CX1Doc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX1View)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CX1View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CX1View)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in X1View.cpp
inline CX1Doc* CX1View::GetDocument()
   { return (CX1Doc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X1VIEW_H__8FA20F1D_C3B9_11D6_878A_000021F57B37__INCLUDED_)
