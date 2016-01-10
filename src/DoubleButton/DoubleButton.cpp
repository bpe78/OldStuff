#include "stdafx.h"
#include "DoubleButton.h"


// CDoubleButton

CDoubleButton::CDoubleButton()
{
  m_nLeft = 0;
  m_nTop = 0;
}

CDoubleButton::CDoubleButton(CWnd *pParentWnd, int nLeft, int nTop, int nWidth, int nHeight, LPCSTR lpString1, LPCSTR lpString2)
{
  m_nLeft = nLeft;
  m_nTop = nTop;
  m_nRight = nLeft + nWidth;
  m_nBottom = nTop + nHeight;

  CRect rectStatic1(m_nLeft, m_nTop, m_nLeft + nWidth/4, m_nTop + 18);
  m_ctrlStringBefore.Create(lpString1, WS_CHILD | WS_VISIBLE, rectStatic1, pParentWnd);

  CRect rectEdit(m_nLeft + nWidth/4, m_nTop - 2, m_nLeft + 3*nWidth/4, m_nTop + 22);
  m_ctrlEdit.CreateEx(WS_EX_CLIENTEDGE, _T("EDIT"), _T(""), WS_CHILD | WS_VISIBLE | WS_TABSTOP | WS_BORDER | ES_RIGHT | ES_NUMBER, rectEdit, pParentWnd, 1001);

  CRect rectStatic2(m_nLeft + 3*nWidth/4 + 5, m_nTop, m_nLeft + nWidth, m_nTop + 18);
  m_ctrlStringAfter.Create(lpString2, WS_CHILD | WS_VISIBLE, rectStatic2, pParentWnd);
}

CDoubleButton::~CDoubleButton()
{
}


BEGIN_MESSAGE_MAP(CDoubleButton, CWnd)
	//{{AFX_MSG_MAP(CDoubleButton)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

