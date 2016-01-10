// RulerView.h : interface of the CRulerView class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_RULERVIEW_H__423CF1B7_A543_4F68_833F_3DC5C93DEDB9__INCLUDED_)
#define AFX_RULERVIEW_H__423CF1B7_A543_4F68_833F_3DC5C93DEDB9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CRulerView : public CView
{
protected: // create from serialization only
	CRulerView();
	DECLARE_DYNCREATE(CRulerView)

// Attributes
public:
	CRulerDoc* GetDocument();
  void DrawRuler(CPoint &ptOldPoint, CPoint &ptNewPoint, bool bSetPoint=TRUE);

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRulerView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CRulerView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CRulerView)
	afx_msg void OnRuler();
	afx_msg void OnMouseMove(UINT nFlags, CPoint point);
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
  bool m_bRulerOn;
  CPoint m_ptOldPoint;
};

#ifndef _DEBUG  // debug version in RulerView.cpp
inline CRulerDoc* CRulerView::GetDocument()
   { return (CRulerDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_RULERVIEW_H__423CF1B7_A543_4F68_833F_3DC5C93DEDB9__INCLUDED_)
