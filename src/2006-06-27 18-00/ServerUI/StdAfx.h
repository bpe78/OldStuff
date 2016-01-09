// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D75BD3AA_CD43_4582_80F3_96E376399F12__INCLUDED_)
#define AFX_STDAFX_H__D75BD3AA_CD43_4582_80F3_96E376399F12__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <atlbase.h>
#include <objbase.h>
#include <afxmt.h>
#include <stdio.h>
#include <vector>
#import "..\MTMessageServer\MTMessageServer.tlb" no_namespace named_guids

#include "Resource.h"


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D75BD3AA_CD43_4582_80F3_96E376399F12__INCLUDED_)
