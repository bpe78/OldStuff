#if !defined(__X1_H__)
#define __X1_H__

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CX1App:
// See X1.cpp for the implementation of this class
//

class CX1App : public CWinApp
{
public:
	CX1App();


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CX1App)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation
	//{{AFX_MSG(CX1App)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_X1_H__115DACA5_0D9F_11D7_87F6_000021F57B37__INCLUDED_)
