#include "stdafx.h"
#include "Lista.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CLista::CLista()
{
  m_lMin = 0;
  m_lMax = 0;
  InitializeCriticalSection(&m_cs);
}

CLista::~CLista()
{
  DeleteCriticalSection(&m_cs);
  m_listElements.clear();
}

boolean CLista::PushMessage(CString strMessage)
{
  boolean bResult = FALSE;
  EnterCriticalSection(&m_cs);
  if(m_listElements.size() < m_lMax)
  {
    m_listElements.push_back(strMessage);
    bResult = TRUE;
  }
  LeaveCriticalSection(&m_cs);

  return bResult;
}

boolean CLista::PopMessage(CString &strMessage)
{
  boolean bResult = FALSE;

  EnterCriticalSection(&m_cs);
  if(m_listElements.size() > max(0, m_lMin))
  {
    strMessage = m_listElements.front();
    m_listElements.pop_front();
    bResult = TRUE;
  }
  LeaveCriticalSection(&m_cs);
  return bResult;
}

long CLista::Size()
{
  long lSize = 0;
  EnterCriticalSection(&m_cs);
  lSize = m_listElements.size();
  LeaveCriticalSection(&m_cs);

  return lSize;
}

void CLista::Clear()
{
  EnterCriticalSection(&m_cs);
  m_listElements.clear();
  LeaveCriticalSection(&m_cs);
}

void CLista::SetLimits(long lMin, long lMax)
{
  EnterCriticalSection(&m_cs);
  m_lMin = lMin;
  m_lMax = lMax;
  LeaveCriticalSection(&m_cs);
}

boolean CLista::CanPushMessage()
{
  boolean bResult;
  EnterCriticalSection(&m_cs);
  if(m_listElements.size() < m_lMax)
    bResult = TRUE;
  else
    bResult = FALSE;
  LeaveCriticalSection(&m_cs);
  
  return bResult;
}

boolean CLista::CanPopMessage()
{
  boolean bResult;
  EnterCriticalSection(&m_cs);
  if(m_listElements.size() > max(0, m_lMin))
    bResult = TRUE;
  else
    bResult = FALSE;
  LeaveCriticalSection(&m_cs);

  return bResult;
}
