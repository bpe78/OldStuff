#include "stdafx.h"
#include "DlgLogOptions.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlgLogOptions dialog


CDlgLogOptions::CDlgLogOptions(CWnd* pParent /*=NULL*/)
	: CDialog(CDlgLogOptions::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDlgLogOptions)
	//}}AFX_DATA_INIT
}


void CDlgLogOptions::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlgLogOptions)
	DDX_Control(pDX, IDC_LOG_FILENAME, m_ctrlFilename);
	DDX_Control(pDX, IDC_CB_LOG_LEVEL, m_ctrlLevels);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDlgLogOptions, CDialog)
	//{{AFX_MSG_MAP(CDlgLogOptions)
	ON_BN_CLICKED(IDC_BTN_LOG_BROWSE, OnLogBrowse)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlgLogOptions message handlers

void CDlgLogOptions::OnLogBrowse() 
{
}

void CDlgLogOptions::OnOK() 
{
  CDialog::OnOK();

  // save options into registry
  HRESULT hr;
  CComPtr<ISettings> spSettings;

  hr = CoCreateInstance(CLSID_Settings, NULL, CLSCTX_INPROC_SERVER, IID_ISettings, (void**)&spSettings);
  
  if(SUCCEEDED(hr))
  {
    CString strFilename;
    m_ctrlFilename.GetWindowText(strFilename);
    spSettings->SetLogFilename((BSTR)CComBSTR(strFilename));
    spSettings->SetLogLevel(m_ctrlLevels.GetCurSel());
  }
}

BOOL CDlgLogOptions::OnInitDialog() 
{
	CDialog::OnInitDialog();

  // Functionality not implemented yet !!!
  m_ctrlFilename.EnableWindow(FALSE);
  GetDlgItem(IDC_BTN_LOG_BROWSE)->EnableWindow(FALSE);
  
  // retrieve settings from registry
  HRESULT hr;
  long lLevel = 0;
  CString strFilename;

  // fill controls with info from logging server
  CComPtr<ILogger> spLogger;
  hr = CoCreateInstance(CLSID_Logger, NULL, CLSCTX_INPROC_SERVER, IID_ILogger, (void**)&spLogger);

  if(SUCCEEDED(hr))
  {
    const int iLLSize = sizeof(eLoggingLevel)+1;  // size of arrays to receive info from server
    
    BSTR arrNames[iLLSize];
    long arrIDs[iLLSize];
    spLogger->GetLLDetails(arrNames, arrIDs);
    for(int i=0; i<iLLSize; i++)
    {
      m_ctrlLevels.AddString(CString(arrNames[i]));
      m_vecValues.push_back(arrIDs[i]);

      SysFreeString(arrNames[i]);
    }
  }
  else
  {
    AfxMessageBox("Log component not available");
    return FALSE;
  }

  // get options from registry
  CComPtr<ISettings> spSettings;
  hr = CoCreateInstance(CLSID_Settings, NULL, CLSCTX_INPROC_SERVER, IID_ISettings, (void**)&spSettings);
  if(SUCCEEDED(hr))
  {
    BSTR bstrFilename;
    spSettings->GetLogLevel(&lLevel);
    spSettings->GetLogFilename(&bstrFilename);
    strFilename = CString(bstrFilename);

    SysFreeString(bstrFilename);
  }

  m_ctrlFilename.SetWindowText(strFilename);
  m_ctrlLevels.SetCurSel(lLevel);

	return TRUE;
}
