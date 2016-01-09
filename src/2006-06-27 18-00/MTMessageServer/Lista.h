// Lista.h: interface for the CLista class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_LISTA_H__CB665504_B773_43D0_B514_60741BB53438__INCLUDED_)
#define AFX_LISTA_H__CB665504_B773_43D0_B514_60741BB53438__INCLUDED_

#pragma once

class CLista  
{
public:
	boolean CanPopMessage();
	boolean CanPushMessage();
  CLista();
	virtual ~CLista();

  boolean PopMessage(CString &strMessage);
  boolean PushMessage(CString strMessage);
  void SetLimits(long lMin, long lMax);
  void Clear();
  long Size();
  
private:
  CRITICAL_SECTION m_cs;
  std::list<CString> m_listElements;
  long m_lMin;
  long m_lMax;
};

#endif // !defined(AFX_LISTA_H__CB665504_B773_43D0_B514_60741BB53438__INCLUDED_)
