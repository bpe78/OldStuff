// X3View.h : interface of the CX3View class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_X3VIEW_H__3986E7AB_1ADC_4588_8C8E_448AC072578F__INCLUDED_)
#define AFX_X3VIEW_H__3986E7AB_1ADC_4588_8C8E_448AC072578F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CX3View : public CView
{
protected: // create from serialization only
	CX3View();
	DECLARE_DYNCREATE(CX3View)

// Attributes
public:
	CX3Doc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX3View)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CX3View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CX3View)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in X3View.cpp
inline CX3Doc* CX3View::GetDocument()
   { return (CX3Doc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X3VIEW_H__3986E7AB_1ADC_4588_8C8E_448AC072578F__INCLUDED_)
