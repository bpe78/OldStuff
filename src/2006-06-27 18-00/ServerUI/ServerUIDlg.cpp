#include "stdafx.h"
#include "ServerUI.h"
#include "DlgLogOptions.h"
#include "ServerUIDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


/////////////////////////////////////////////////////////////////////////////
// CServerUIDlg dialog

CServerUIDlg::CServerUIDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CServerUIDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CServerUIDlg)
	m_nNbClientThreadsStart = 0;
	m_nNbServerThreadsStart = 0;
  m_nNbClientThreadsStop  = 0;
  m_nNbServerThreadsStop  = 0;
	m_nSleepTimeClients = 0;
	m_nSleepTimeServers = 0;
  m_nQueueMinMessages = 0;
  m_nQueueMaxMessages = 0;
	m_lClientsRunning = 0;
	m_lServersRunning = 0;
	//}}AFX_DATA_INIT
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CServerUIDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CServerUIDlg)
	DDX_Control(pDX, IDC_LIST_QUEUE, m_lbQueue);
	DDX_Text(pDX, IDC_CA_NBCLIENTS_START, m_nNbClientThreadsStart);
	DDX_Text(pDX, IDC_CA_NBSERVERS_START, m_nNbServerThreadsStart);
  DDX_Text(pDX, IDC_CA_NBCLIENTS_STOP, m_nNbClientThreadsStop);
  DDX_Text(pDX, IDC_CA_NBSERVERS_STOP, m_nNbServerThreadsStop);
	DDX_Text(pDX, IDC_CA_SLEEP_CLIENT, m_nSleepTimeClients);
	DDX_Text(pDX, IDC_CA_SLEEP_SERVER, m_nSleepTimeServers);
	DDX_Text(pDX, IDC_CA_QUEUE_MIN, m_nQueueMinMessages);
  DDX_Text(pDX, IDC_CA_QUEUE_MAX, m_nQueueMaxMessages);
	DDX_Text(pDX, IDC_RUNNING_CLIENT_THREADS, m_lClientsRunning);
	DDX_Text(pDX, IDC_RUNNING_SERVER_THREADS, m_lServersRunning);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CServerUIDlg, CDialog)
	//{{AFX_MSG_MAP(CServerUIDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
  ON_BN_CLICKED(IDC_BTN_CA_CLIENTS_START, OnClientsStart)
  ON_BN_CLICKED(IDC_BTN_CA_SERVERS_START, OnServersStart)
  ON_BN_CLICKED(IDC_BTN_CA_CLIENTS_STOP, OnClientsStop)
  ON_BN_CLICKED(IDC_BTN_CA_SERVERS_STOP, OnServersStop)
  ON_BN_CLICKED(IDC_BTN_CA_SLEEP_CLIENT, OnSetSleepClient)
  ON_BN_CLICKED(IDC_BTN_CA_SLEEP_SERVER, OnSetSleepServer)
  ON_BN_CLICKED(IDC_BTN_CA_QUEUE_MIN, OnQueueMin)
	ON_BN_CLICKED(IDC_BTN_CA_QUEUE_MAX, OnQueueMax)
  ON_BN_CLICKED(IDC_BTN_DISPLAY_CLEAR, OnDisplayClear)
  ON_BN_CLICKED(IDC_BTN_DISPLAY_STOP, OnDisplayStop)
	ON_BN_CLICKED(IDC_BTN_LOG_OPTIONS, OnLogOptions)
  ON_BN_CLICKED(IDC_BTN_LOG_DISPLAY, OnLogDisplay)
  ON_BN_CLICKED(IDC_BTN_APPLICATION_EXIT, OnBtnApplicationExit)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CServerUIDlg message handlers

BOOL CServerUIDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
  LoadSettings();

  HRESULT hr;
  
  if(IsMessageQueueAvailable())
  {
    hr = m_spMessageQueue->AddUIListener(GetCurrentThreadId());
    ASSERT(SUCCEEDED(hr));
    VARIANT vtInit;
    vtInit.vt = VT_I4;
    vtInit.lVal = C_SleepTimeClients | C_SleepTimeServers | C_QueueMinMessages | C_QueueMaxMessages;

    hr = m_spMessageQueue->UpdateConfiguration(vtInit,
                                               0, 0,
                                               0, 0,
                                               m_nSleepTimeClients, m_nSleepTimeServers,
                                               m_nQueueMinMessages, m_nQueueMaxMessages);
    ASSERT(SUCCEEDED(hr));
  }    

	return TRUE;
}


// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CServerUIDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CServerUIDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

// processes messages sent from the server
BOOL CServerUIDlg::PreTranslateMessage(MSG* pMsg) 
{
  BOOL bResult = CDialog::PreTranslateMessage(pMsg);

  if(bResult)
    return bResult;

  switch(pMsg->message)
  {
    case TM_AddMessage :
    {
      char *strMessage = (char *)pMsg->lParam;
      m_lbQueue.AddString(strMessage);
      CoTaskMemFree(strMessage);
      
      return TRUE; // message processed, don't send further
    } break;
    
    case TM_DelMessage :
    {
      if(m_lbQueue.GetCount() > 0)
      {
        m_lbQueue.DeleteString(0);
      }
      
      return TRUE; // message processed, don't send further
    } break;
  }      
  
  return FALSE;
}


void CServerUIDlg::OnClientsStart() 
{
  UpdateServerConfiguration(C_ClientThreadsStart);

  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->GetRunningClientThreads(&m_lClientsRunning);
  }

  UpdateData(FALSE);
}

void CServerUIDlg::OnServersStart() 
{
  UpdateServerConfiguration(C_ServerThreadsStart);

  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->GetRunningServerThreads(&m_lServersRunning);
  }
  
  UpdateData(FALSE);
}

void CServerUIDlg::OnClientsStop() 
{
  UpdateServerConfiguration(C_ClientThreadsStop);

  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->GetRunningClientThreads(&m_lClientsRunning);
  }
  
  UpdateData(FALSE);
}

void CServerUIDlg::OnServersStop() 
{
  UpdateServerConfiguration(C_ServerThreadsStop);

  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->GetRunningServerThreads(&m_lServersRunning);
  }
  
  UpdateData(FALSE);
}

void CServerUIDlg::OnSetSleepClient() 
{
  UpdateServerConfiguration(C_SleepTimeClients);
}

void CServerUIDlg::OnSetSleepServer() 
{
  UpdateServerConfiguration(C_SleepTimeServers);
}

void CServerUIDlg::OnQueueMin() 
{
  UpdateServerConfiguration(C_QueueMinMessages);
}

void CServerUIDlg::OnQueueMax() 
{
  UpdateServerConfiguration(C_QueueMaxMessages);
}


void CServerUIDlg::OnDisplayClear() 
{
  ClearMessageQueue();
}

void CServerUIDlg::OnDisplayStop() 
{
  StopMessageQueue();

  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->GetRunningClientThreads(&m_lClientsRunning);
    m_spMessageQueue->GetRunningServerThreads(&m_lServersRunning);
  }
  
  UpdateData(FALSE);
}


void CServerUIDlg::OnLogOptions() 
{
  CDlgLogOptions dlg(this);
  dlg.DoModal();
}

void CServerUIDlg::OnLogDisplay() 
{
  HRESULT hr;

  if(IsLoggerAvailable())
  {
    hr = m_spLogger->DisplayLog();
    ASSERT(SUCCEEDED(hr));
  }
}


void CServerUIDlg::OnBtnApplicationExit() 
{
  // perform cleanup
  StopMessageQueue();
  // save settings in registry
  SaveSettings();
  // end application
  EndDialog(IDOK);
}

//////////////////////
/// Helper Methods ///
//////////////////////

/////////////////////////
/// Interface helpers ///
/////////////////////////

boolean CServerUIDlg::IsSettingsAvailable()
{
  if(m_spSettings != NULL)
    return TRUE;

  HRESULT hr;
  hr = CoCreateInstance(CLSID_Settings, NULL, CLSCTX_INPROC_SERVER, IID_ISettings, (void**)&m_spSettings);
  if(FAILED(hr))
  {
    m_spSettings = NULL;
    AfxMessageBox("<Settings component> not available");
    return FALSE;
  }

  return TRUE;
}

boolean CServerUIDlg::IsLoggerAvailable()
{
  if(m_spLogger != NULL)
    return TRUE;

  HRESULT hr;
  hr = CoCreateInstance(CLSID_Logger, NULL, CLSCTX_INPROC_SERVER, IID_ILogger, (void**)&m_spLogger);
  if(FAILED(hr))
  {
    m_spLogger = NULL;
    AfxMessageBox("<Log component> not available");
    return FALSE;
  }

  return TRUE;
}


boolean CServerUIDlg::IsMessageQueueAvailable()
{
  if(m_spMessageQueue != NULL)
    return TRUE;

  HRESULT hr;
  hr = CoCreateInstance(CLSID_MessageQueue, NULL, CLSCTX_INPROC_SERVER, IID_IMessageQueue, (void**)&m_spMessageQueue);
  if(FAILED(hr))
  {
    m_spMessageQueue = NULL;
    AfxMessageBox("<Queue component> not available");
    return FALSE;
  }

  return TRUE;
}


////////////////////////
/// Settings helpers ///
////////////////////////

void CServerUIDlg::LoadSettings()
{
  HRESULT hr;
  
  if(IsSettingsAvailable())
  {
    hr = m_spSettings->GetClientThreadsStartNumber(&m_nNbClientThreadsStart);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetServerThreadsStartNumber(&m_nNbServerThreadsStart);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetClientThreadsStopNumber(&m_nNbClientThreadsStop);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetServerThreadsStopNumber(&m_nNbServerThreadsStop);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetClientThreadsSleepTime(&m_nSleepTimeClients);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetServerThreadsSleepTime(&m_nSleepTimeServers);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetQueueMinMessages(&m_nQueueMinMessages);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->GetQueueMaxMessages(&m_nQueueMaxMessages);
    ASSERT(SUCCEEDED(hr));
  }
  
  UpdateData(FALSE);
}

void CServerUIDlg::SaveSettings()
{
  HRESULT hr;
  
  UpdateData(TRUE);

  if(IsSettingsAvailable())
  {
    hr = m_spSettings->SetClientThreadsStartNumber(m_nNbClientThreadsStart);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetServerThreadsStartNumber(m_nNbServerThreadsStart);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetClientThreadsStopNumber(m_nNbClientThreadsStop);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetServerThreadsStopNumber(m_nNbServerThreadsStop);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetClientThreadsSleepTime(m_nSleepTimeClients);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetServerThreadsSleepTime(m_nSleepTimeServers);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetQueueMinMessages(m_nQueueMinMessages);
    ASSERT(SUCCEEDED(hr));
    hr = m_spSettings->SetQueueMaxMessages(m_nQueueMaxMessages);
    ASSERT(SUCCEEDED(hr));
  }
}

//////////////////
/// UI Helpers ///
//////////////////

void CServerUIDlg::UpdateServerConfiguration(eConfiguration eConfig)
{
  HRESULT hr;

  UpdateData(TRUE);

  if(IsMessageQueueAvailable())
  {
    VARIANT vtInit;
    vtInit.vt = VT_I4;
    vtInit.lVal = eConfig;
    
    hr = m_spMessageQueue->UpdateConfiguration(vtInit,
                                               m_nNbClientThreadsStart, m_nNbServerThreadsStart,
                                               m_nNbClientThreadsStop, m_nNbServerThreadsStop,
                                               m_nSleepTimeClients, m_nSleepTimeServers,
                                               m_nQueueMinMessages, m_nQueueMaxMessages);
    ASSERT(SUCCEEDED(hr));
  }
}

void CServerUIDlg::ClearMessageQueue()
{
  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->ClearQueue();
  }
  
  m_lbQueue.ResetContent();
}

void CServerUIDlg::StopMessageQueue()
{
  if(IsMessageQueueAvailable())
  {
    m_spMessageQueue->StopQueue();
  }
  
  m_lbQueue.ResetContent();
}

