#if !defined(_DOUBLEBUTTON_H__)
#define _DOUBLEBUTTON_H__

#define TYPE_BUTTON 1000

// CDoubleButton
class CDoubleButton : public CWnd
{
// Attributes
private:
  CEdit m_ctrlEdit;
  CStatic m_ctrlStringBefore;
  CStatic m_ctrlStringAfter;
  int m_nLeft, m_nTop, m_nRight, m_nBottom;
// Functions
public:
	CDoubleButton();
  CDoubleButton(CWnd *pParentWnd, int nLeft, int nTop, int nWidth, int nHeight, LPCSTR lpString1, LPCSTR lpString2);
  
  // TDoubleButton
  //CDoubleButton(/*CWnd *pParentWnd,*/UINT nLeft, WORD nTop, WORD nWidth, WORD nHeight, LPCSTR lpDescription, WORD nNotUsed1/*vBrac*/, LPCSTR lpToolTip, double *vVarMask, double dfMinValue, double dfMaxValue, unite_type vTypUnite, UINT ButtonID, void *NotUsed/*vSuivV*/, BOOL bShowUnits, double vpixDebSaisie, double vpixFinSaisie);
  //CDoubleButton(/*CWnd *pParentWnd,*/UINT nLeft, UINT nTop, UINT nWidth, UINT nHeight, LPCSTR lpDescription, WORD nNotUsed1/*vBrac*/, LPCSTR lpToolTip, double *vVarMask, double dfMinValue, double dfMaxValue, UINT ButtonID, void *NotUsed/*vSuivV*/, double vpixDebSaisie, double vpixFinSaisie);

  ~CDoubleButton();
  UINT WhatIs(){return TYPE_BUTTON;};
  double GetValue();
  double SetValue(double dNewValue);

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDoubleButton)
	//}}AFX_VIRTUAL

	// Generated message map functions
protected:
	//{{AFX_MSG(CDoubleButton)
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
};


#endif
