/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 5.01.0164 */
/* at Fri Jul 07 12:59:29 2006
 */
/* Compiler settings for E:\Backup Proiecte\2006-06-27 18-00\MTMessageServer\MTMessageServer.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __MTMessageServer_h__
#define __MTMessageServer_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __ISettings_FWD_DEFINED__
#define __ISettings_FWD_DEFINED__
typedef interface ISettings ISettings;
#endif 	/* __ISettings_FWD_DEFINED__ */


#ifndef __ILogger_FWD_DEFINED__
#define __ILogger_FWD_DEFINED__
typedef interface ILogger ILogger;
#endif 	/* __ILogger_FWD_DEFINED__ */


#ifndef __IMessageQueue_FWD_DEFINED__
#define __IMessageQueue_FWD_DEFINED__
typedef interface IMessageQueue IMessageQueue;
#endif 	/* __IMessageQueue_FWD_DEFINED__ */


#ifndef __Settings_FWD_DEFINED__
#define __Settings_FWD_DEFINED__

#ifdef __cplusplus
typedef class Settings Settings;
#else
typedef struct Settings Settings;
#endif /* __cplusplus */

#endif 	/* __Settings_FWD_DEFINED__ */


#ifndef __Logger_FWD_DEFINED__
#define __Logger_FWD_DEFINED__

#ifdef __cplusplus
typedef class Logger Logger;
#else
typedef struct Logger Logger;
#endif /* __cplusplus */

#endif 	/* __Logger_FWD_DEFINED__ */


#ifndef __MessageQueue_FWD_DEFINED__
#define __MessageQueue_FWD_DEFINED__

#ifdef __cplusplus
typedef class MessageQueue MessageQueue;
#else
typedef struct MessageQueue MessageQueue;
#endif /* __cplusplus */

#endif 	/* __MessageQueue_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __ISettings_INTERFACE_DEFINED__
#define __ISettings_INTERFACE_DEFINED__

/* interface ISettings */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_ISettings;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("3F899350-5F7F-4962-A447-7DD8A0FD1FA2")
    ISettings : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetClientThreadsStartNumber( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetClientThreadsStartNumber( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetClientThreadsStopNumber( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetClientThreadsStopNumber( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetServerThreadsStartNumber( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetServerThreadsStartNumber( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetServerThreadsStopNumber( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetServerThreadsStopNumber( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetClientThreadsSleepTime( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetClientThreadsSleepTime( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetServerThreadsSleepTime( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetServerThreadsSleepTime( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetQueueMinMessages( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetQueueMinMessages( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetQueueMaxMessages( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetQueueMaxMessages( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetLogLevel( 
            /* [out] */ long __RPC_FAR *lpValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetLogLevel( 
            /* [in] */ long lValue) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetLogFilename( 
            /* [out] */ BSTR __RPC_FAR *bstrFilename) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetLogFilename( 
            /* [in] */ BSTR bstrFilename) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISettingsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            ISettings __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            ISettings __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            ISettings __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetClientThreadsStartNumber )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetClientThreadsStartNumber )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetClientThreadsStopNumber )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetClientThreadsStopNumber )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetServerThreadsStartNumber )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetServerThreadsStartNumber )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetServerThreadsStopNumber )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetServerThreadsStopNumber )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetClientThreadsSleepTime )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetClientThreadsSleepTime )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetServerThreadsSleepTime )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetServerThreadsSleepTime )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetQueueMinMessages )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetQueueMinMessages )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetQueueMaxMessages )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetQueueMaxMessages )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetLogLevel )( 
            ISettings __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *lpValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetLogLevel )( 
            ISettings __RPC_FAR * This,
            /* [in] */ long lValue);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetLogFilename )( 
            ISettings __RPC_FAR * This,
            /* [out] */ BSTR __RPC_FAR *bstrFilename);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetLogFilename )( 
            ISettings __RPC_FAR * This,
            /* [in] */ BSTR bstrFilename);
        
        END_INTERFACE
    } ISettingsVtbl;

    interface ISettings
    {
        CONST_VTBL struct ISettingsVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISettings_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISettings_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISettings_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISettings_GetClientThreadsStartNumber(This,lpValue)	\
    (This)->lpVtbl -> GetClientThreadsStartNumber(This,lpValue)

#define ISettings_SetClientThreadsStartNumber(This,lValue)	\
    (This)->lpVtbl -> SetClientThreadsStartNumber(This,lValue)

#define ISettings_GetClientThreadsStopNumber(This,lpValue)	\
    (This)->lpVtbl -> GetClientThreadsStopNumber(This,lpValue)

#define ISettings_SetClientThreadsStopNumber(This,lValue)	\
    (This)->lpVtbl -> SetClientThreadsStopNumber(This,lValue)

#define ISettings_GetServerThreadsStartNumber(This,lpValue)	\
    (This)->lpVtbl -> GetServerThreadsStartNumber(This,lpValue)

#define ISettings_SetServerThreadsStartNumber(This,lValue)	\
    (This)->lpVtbl -> SetServerThreadsStartNumber(This,lValue)

#define ISettings_GetServerThreadsStopNumber(This,lpValue)	\
    (This)->lpVtbl -> GetServerThreadsStopNumber(This,lpValue)

#define ISettings_SetServerThreadsStopNumber(This,lValue)	\
    (This)->lpVtbl -> SetServerThreadsStopNumber(This,lValue)

#define ISettings_GetClientThreadsSleepTime(This,lpValue)	\
    (This)->lpVtbl -> GetClientThreadsSleepTime(This,lpValue)

#define ISettings_SetClientThreadsSleepTime(This,lValue)	\
    (This)->lpVtbl -> SetClientThreadsSleepTime(This,lValue)

#define ISettings_SetServerThreadsSleepTime(This,lValue)	\
    (This)->lpVtbl -> SetServerThreadsSleepTime(This,lValue)

#define ISettings_GetServerThreadsSleepTime(This,lpValue)	\
    (This)->lpVtbl -> GetServerThreadsSleepTime(This,lpValue)

#define ISettings_GetQueueMinMessages(This,lpValue)	\
    (This)->lpVtbl -> GetQueueMinMessages(This,lpValue)

#define ISettings_SetQueueMinMessages(This,lValue)	\
    (This)->lpVtbl -> SetQueueMinMessages(This,lValue)

#define ISettings_GetQueueMaxMessages(This,lpValue)	\
    (This)->lpVtbl -> GetQueueMaxMessages(This,lpValue)

#define ISettings_SetQueueMaxMessages(This,lValue)	\
    (This)->lpVtbl -> SetQueueMaxMessages(This,lValue)

#define ISettings_GetLogLevel(This,lpValue)	\
    (This)->lpVtbl -> GetLogLevel(This,lpValue)

#define ISettings_SetLogLevel(This,lValue)	\
    (This)->lpVtbl -> SetLogLevel(This,lValue)

#define ISettings_GetLogFilename(This,bstrFilename)	\
    (This)->lpVtbl -> GetLogFilename(This,bstrFilename)

#define ISettings_SetLogFilename(This,bstrFilename)	\
    (This)->lpVtbl -> SetLogFilename(This,bstrFilename)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetClientThreadsStartNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetClientThreadsStartNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetClientThreadsStartNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetClientThreadsStartNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetClientThreadsStopNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetClientThreadsStopNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetClientThreadsStopNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetClientThreadsStopNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetServerThreadsStartNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetServerThreadsStartNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetServerThreadsStartNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetServerThreadsStartNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetServerThreadsStopNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetServerThreadsStopNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetServerThreadsStopNumber_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetServerThreadsStopNumber_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetClientThreadsSleepTime_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetClientThreadsSleepTime_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetClientThreadsSleepTime_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetClientThreadsSleepTime_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetServerThreadsSleepTime_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetServerThreadsSleepTime_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetServerThreadsSleepTime_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetServerThreadsSleepTime_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetQueueMinMessages_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetQueueMinMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetQueueMinMessages_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetQueueMinMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetQueueMaxMessages_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetQueueMaxMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetQueueMaxMessages_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetQueueMaxMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetLogLevel_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *lpValue);


void __RPC_STUB ISettings_GetLogLevel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetLogLevel_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ long lValue);


void __RPC_STUB ISettings_SetLogLevel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_GetLogFilename_Proxy( 
    ISettings __RPC_FAR * This,
    /* [out] */ BSTR __RPC_FAR *bstrFilename);


void __RPC_STUB ISettings_GetLogFilename_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISettings_SetLogFilename_Proxy( 
    ISettings __RPC_FAR * This,
    /* [in] */ BSTR bstrFilename);


void __RPC_STUB ISettings_SetLogFilename_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISettings_INTERFACE_DEFINED__ */


#ifndef __ILogger_INTERFACE_DEFINED__
#define __ILogger_INTERFACE_DEFINED__

/* interface ILogger */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_ILogger;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B28AB798-6313-479E-BD01-6619B740965C")
    ILogger : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE DisplayLog( void) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE AddLogEntry( 
            /* [in] */ byte bType,
            /* [in] */ long lThreadID,
            /* [in] */ long lNumber,
            /* [in] */ BSTR bstrDescription) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetLoggingLevel( 
            /* [in] */ byte bLevel) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetLLDetails( 
            /* [out] */ BSTR __RPC_FAR arrLevelName[ 5 ],
            /* [out] */ long __RPC_FAR arrLevelID[ 5 ]) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ILoggerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            ILogger __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            ILogger __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            ILogger __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DisplayLog )( 
            ILogger __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *AddLogEntry )( 
            ILogger __RPC_FAR * This,
            /* [in] */ byte bType,
            /* [in] */ long lThreadID,
            /* [in] */ long lNumber,
            /* [in] */ BSTR bstrDescription);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetLoggingLevel )( 
            ILogger __RPC_FAR * This,
            /* [in] */ byte bLevel);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetLLDetails )( 
            ILogger __RPC_FAR * This,
            /* [out] */ BSTR __RPC_FAR arrLevelName[ 5 ],
            /* [out] */ long __RPC_FAR arrLevelID[ 5 ]);
        
        END_INTERFACE
    } ILoggerVtbl;

    interface ILogger
    {
        CONST_VTBL struct ILoggerVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ILogger_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ILogger_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ILogger_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ILogger_DisplayLog(This)	\
    (This)->lpVtbl -> DisplayLog(This)

#define ILogger_AddLogEntry(This,bType,lThreadID,lNumber,bstrDescription)	\
    (This)->lpVtbl -> AddLogEntry(This,bType,lThreadID,lNumber,bstrDescription)

#define ILogger_SetLoggingLevel(This,bLevel)	\
    (This)->lpVtbl -> SetLoggingLevel(This,bLevel)

#define ILogger_GetLLDetails(This,arrLevelName,arrLevelID)	\
    (This)->lpVtbl -> GetLLDetails(This,arrLevelName,arrLevelID)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE ILogger_DisplayLog_Proxy( 
    ILogger __RPC_FAR * This);


void __RPC_STUB ILogger_DisplayLog_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ILogger_AddLogEntry_Proxy( 
    ILogger __RPC_FAR * This,
    /* [in] */ byte bType,
    /* [in] */ long lThreadID,
    /* [in] */ long lNumber,
    /* [in] */ BSTR bstrDescription);


void __RPC_STUB ILogger_AddLogEntry_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ILogger_SetLoggingLevel_Proxy( 
    ILogger __RPC_FAR * This,
    /* [in] */ byte bLevel);


void __RPC_STUB ILogger_SetLoggingLevel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ILogger_GetLLDetails_Proxy( 
    ILogger __RPC_FAR * This,
    /* [out] */ BSTR __RPC_FAR arrLevelName[ 5 ],
    /* [out] */ long __RPC_FAR arrLevelID[ 5 ]);


void __RPC_STUB ILogger_GetLLDetails_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ILogger_INTERFACE_DEFINED__ */


#ifndef __IMessageQueue_INTERFACE_DEFINED__
#define __IMessageQueue_INTERFACE_DEFINED__

/* interface IMessageQueue */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IMessageQueue;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6D782F75-08D2-4C3D-913B-60C40AF4B4D0")
    IMessageQueue : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE PushMessage( 
            /* [in] */ long lThreadID,
            /* [in] */ BSTR bstrMessage) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE PopMessage( 
            /* [out] */ VARIANT __RPC_FAR *pvtValid,
            /* [out] */ BSTR __RPC_FAR *pbstrMessage) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE AddUIListener( 
            /* [in] */ long lThreadID) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE UpdateConfiguration( 
            /* [in] */ VARIANT vtInitialize,
            /* [in] */ long m_lNbClientThreadsStart,
            /* [in] */ long m_lNbServerThreadsStart,
            /* [in] */ long m_lNbClientThreadsStop,
            /* [in] */ long m_lNbServerThreadsStop,
            /* [in] */ long m_lSleepTimeClients,
            /* [in] */ long m_lSleepTimeServers,
            /* [in] */ long lMinMessages,
            /* [in] */ long lMaxMessages) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CanPushMessages( 
            /* [out] */ VARIANT __RPC_FAR *pvtCanPushMessages) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CanPopMessages( 
            /* [out] */ VARIANT __RPC_FAR *pvtCanPopMessages) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ClearQueue( void) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE StopQueue( void) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRunningClientThreads( 
            /* [out] */ long __RPC_FAR *plClientsRunning) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetRunningServerThreads( 
            /* [out] */ long __RPC_FAR *plServersRunning) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMessageQueueVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IMessageQueue __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IMessageQueue __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IMessageQueue __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *PushMessage )( 
            IMessageQueue __RPC_FAR * This,
            /* [in] */ long lThreadID,
            /* [in] */ BSTR bstrMessage);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *PopMessage )( 
            IMessageQueue __RPC_FAR * This,
            /* [out] */ VARIANT __RPC_FAR *pvtValid,
            /* [out] */ BSTR __RPC_FAR *pbstrMessage);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *AddUIListener )( 
            IMessageQueue __RPC_FAR * This,
            /* [in] */ long lThreadID);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *UpdateConfiguration )( 
            IMessageQueue __RPC_FAR * This,
            /* [in] */ VARIANT vtInitialize,
            /* [in] */ long m_lNbClientThreadsStart,
            /* [in] */ long m_lNbServerThreadsStart,
            /* [in] */ long m_lNbClientThreadsStop,
            /* [in] */ long m_lNbServerThreadsStop,
            /* [in] */ long m_lSleepTimeClients,
            /* [in] */ long m_lSleepTimeServers,
            /* [in] */ long lMinMessages,
            /* [in] */ long lMaxMessages);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CanPushMessages )( 
            IMessageQueue __RPC_FAR * This,
            /* [out] */ VARIANT __RPC_FAR *pvtCanPushMessages);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CanPopMessages )( 
            IMessageQueue __RPC_FAR * This,
            /* [out] */ VARIANT __RPC_FAR *pvtCanPopMessages);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ClearQueue )( 
            IMessageQueue __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *StopQueue )( 
            IMessageQueue __RPC_FAR * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetRunningClientThreads )( 
            IMessageQueue __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *plClientsRunning);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetRunningServerThreads )( 
            IMessageQueue __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *plServersRunning);
        
        END_INTERFACE
    } IMessageQueueVtbl;

    interface IMessageQueue
    {
        CONST_VTBL struct IMessageQueueVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMessageQueue_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMessageQueue_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMessageQueue_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMessageQueue_PushMessage(This,lThreadID,bstrMessage)	\
    (This)->lpVtbl -> PushMessage(This,lThreadID,bstrMessage)

#define IMessageQueue_PopMessage(This,pvtValid,pbstrMessage)	\
    (This)->lpVtbl -> PopMessage(This,pvtValid,pbstrMessage)

#define IMessageQueue_AddUIListener(This,lThreadID)	\
    (This)->lpVtbl -> AddUIListener(This,lThreadID)

#define IMessageQueue_UpdateConfiguration(This,vtInitialize,m_lNbClientThreadsStart,m_lNbServerThreadsStart,m_lNbClientThreadsStop,m_lNbServerThreadsStop,m_lSleepTimeClients,m_lSleepTimeServers,lMinMessages,lMaxMessages)	\
    (This)->lpVtbl -> UpdateConfiguration(This,vtInitialize,m_lNbClientThreadsStart,m_lNbServerThreadsStart,m_lNbClientThreadsStop,m_lNbServerThreadsStop,m_lSleepTimeClients,m_lSleepTimeServers,lMinMessages,lMaxMessages)

#define IMessageQueue_CanPushMessages(This,pvtCanPushMessages)	\
    (This)->lpVtbl -> CanPushMessages(This,pvtCanPushMessages)

#define IMessageQueue_CanPopMessages(This,pvtCanPopMessages)	\
    (This)->lpVtbl -> CanPopMessages(This,pvtCanPopMessages)

#define IMessageQueue_ClearQueue(This)	\
    (This)->lpVtbl -> ClearQueue(This)

#define IMessageQueue_StopQueue(This)	\
    (This)->lpVtbl -> StopQueue(This)

#define IMessageQueue_GetRunningClientThreads(This,plClientsRunning)	\
    (This)->lpVtbl -> GetRunningClientThreads(This,plClientsRunning)

#define IMessageQueue_GetRunningServerThreads(This,plServersRunning)	\
    (This)->lpVtbl -> GetRunningServerThreads(This,plServersRunning)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_PushMessage_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [in] */ long lThreadID,
    /* [in] */ BSTR bstrMessage);


void __RPC_STUB IMessageQueue_PushMessage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_PopMessage_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [out] */ VARIANT __RPC_FAR *pvtValid,
    /* [out] */ BSTR __RPC_FAR *pbstrMessage);


void __RPC_STUB IMessageQueue_PopMessage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_AddUIListener_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [in] */ long lThreadID);


void __RPC_STUB IMessageQueue_AddUIListener_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_UpdateConfiguration_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [in] */ VARIANT vtInitialize,
    /* [in] */ long m_lNbClientThreadsStart,
    /* [in] */ long m_lNbServerThreadsStart,
    /* [in] */ long m_lNbClientThreadsStop,
    /* [in] */ long m_lNbServerThreadsStop,
    /* [in] */ long m_lSleepTimeClients,
    /* [in] */ long m_lSleepTimeServers,
    /* [in] */ long lMinMessages,
    /* [in] */ long lMaxMessages);


void __RPC_STUB IMessageQueue_UpdateConfiguration_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_CanPushMessages_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [out] */ VARIANT __RPC_FAR *pvtCanPushMessages);


void __RPC_STUB IMessageQueue_CanPushMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_CanPopMessages_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [out] */ VARIANT __RPC_FAR *pvtCanPopMessages);


void __RPC_STUB IMessageQueue_CanPopMessages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_ClearQueue_Proxy( 
    IMessageQueue __RPC_FAR * This);


void __RPC_STUB IMessageQueue_ClearQueue_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_StopQueue_Proxy( 
    IMessageQueue __RPC_FAR * This);


void __RPC_STUB IMessageQueue_StopQueue_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_GetRunningClientThreads_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *plClientsRunning);


void __RPC_STUB IMessageQueue_GetRunningClientThreads_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMessageQueue_GetRunningServerThreads_Proxy( 
    IMessageQueue __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *plServersRunning);


void __RPC_STUB IMessageQueue_GetRunningServerThreads_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMessageQueue_INTERFACE_DEFINED__ */



#ifndef __MTMESSAGESERVERLib_LIBRARY_DEFINED__
#define __MTMESSAGESERVERLib_LIBRARY_DEFINED__

/* library MTMESSAGESERVERLib */
/* [helpstring][version][uuid] */ 

typedef /* [public] */ 
enum __MIDL___MIDL_itf_MTMessageServer_0224_0001
    {	ET_MsgServerStart	= 0,
	ET_MsgServerStop	= ET_MsgServerStart + 1,
	ET_MsgClearQueue	= ET_MsgServerStop + 1,
	ET_MsgStopQueue	= ET_MsgClearQueue + 1,
	ET_MsgQueueMin	= ET_MsgStopQueue + 1,
	ET_MsgQueueMax	= ET_MsgQueueMin + 1,
	ET_MsgMessagePush	= ET_MsgQueueMax + 1,
	ET_MsgMessagePop	= ET_MsgMessagePush + 1,
	ET_MsgCThreadChanged	= ET_MsgMessagePop + 1,
	ET_MsgCThreadStarted	= ET_MsgCThreadChanged + 1,
	ET_MsgCThreadStopped	= ET_MsgCThreadStarted + 1,
	ET_MsgSThreadChanged	= ET_MsgCThreadStopped + 1,
	ET_MsgSThreadStarted	= ET_MsgSThreadChanged + 1,
	ET_MsgSThreadStopped	= ET_MsgSThreadStarted + 1,
	ET_MsgErrorinRegistry	= ET_MsgSThreadStopped + 1,
	ET_MsgErrorQueueUnderflow	= ET_MsgErrorinRegistry + 1,
	ET_MsgErrorQueueOverflow	= ET_MsgErrorQueueUnderflow + 1
    }	eEventType;

typedef /* [public] */ 
enum __MIDL___MIDL_itf_MTMessageServer_0224_0002
    {	LL_None	= 0,
	LL_Errors	= LL_None + 1,
	LL_Activity	= LL_Errors + 1,
	LL_UserInterface	= LL_Activity + 1,
	LL_All	= LL_UserInterface + 1
    }	eLoggingLevel;

typedef /* [public] */ 
enum __MIDL___MIDL_itf_MTMessageServer_0224_0003
    {	TM_AddMessage	= 0x401,
	TM_DelMessage	= 0x402
    }	eWndMessageType;

typedef /* [public] */ 
enum __MIDL___MIDL_itf_MTMessageServer_0224_0004
    {	C_ClientThreadsStart	= 0x1,
	C_ServerThreadsStart	= 0x2,
	C_ClientThreadsStop	= 0x4,
	C_ServerThreadsStop	= 0x8,
	C_SleepTimeClients	= 0x10,
	C_SleepTimeServers	= 0x20,
	C_QueueMinMessages	= 0x40,
	C_QueueMaxMessages	= 0x80
    }	eConfiguration;


EXTERN_C const IID LIBID_MTMESSAGESERVERLib;

EXTERN_C const CLSID CLSID_Settings;

#ifdef __cplusplus

class DECLSPEC_UUID("1F980E0B-5793-4C1D-AF65-DAC24C16D9AB")
Settings;
#endif

EXTERN_C const CLSID CLSID_Logger;

#ifdef __cplusplus

class DECLSPEC_UUID("1C71888D-3036-470E-9032-8D19F46165F4")
Logger;
#endif

EXTERN_C const CLSID CLSID_MessageQueue;

#ifdef __cplusplus

class DECLSPEC_UUID("B7C0A554-476D-44BC-976A-2BBAB6218E95")
MessageQueue;
#endif
#endif /* __MTMESSAGESERVERLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long __RPC_FAR *, unsigned long            , BSTR __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  BSTR_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, BSTR __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  BSTR_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, BSTR __RPC_FAR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long __RPC_FAR *, BSTR __RPC_FAR * ); 

unsigned long             __RPC_USER  VARIANT_UserSize(     unsigned long __RPC_FAR *, unsigned long            , VARIANT __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  VARIANT_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, VARIANT __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  VARIANT_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, VARIANT __RPC_FAR * ); 
void                      __RPC_USER  VARIANT_UserFree(     unsigned long __RPC_FAR *, VARIANT __RPC_FAR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
