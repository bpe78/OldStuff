#if !defined(AFX_X1VIEW1_H__115DACB5_0D9F_11D7_87F6_000021F57B37__INCLUDED_)
#define AFX_X1VIEW1_H__115DACB5_0D9F_11D7_87F6_000021F57B37__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// X1View1.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CX1View1 view

class CX1View1 : public CView
{
protected:
	CX1View1();           // protected constructor used by dynamic creation
	DECLARE_DYNCREATE(CX1View1)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX1View1)
	protected:
	virtual void OnDraw(CDC* pDC);      // overridden to draw this view
	//}}AFX_VIRTUAL

// Implementation
protected:
	virtual ~CX1View1();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

	// Generated message map functions
protected:
	//{{AFX_MSG(CX1View1)
		// NOTE - the ClassWizard will add and remove member functions here.
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X1VIEW1_H__115DACB5_0D9F_11D7_87F6_000021F57B37__INCLUDED_)
