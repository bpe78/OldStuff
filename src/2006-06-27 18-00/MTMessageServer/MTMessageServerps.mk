
MTMessageServerps.dll: dlldata.obj MTMessageServer_p.obj MTMessageServer_i.obj
	link /dll /out:MTMessageServerps.dll /def:MTMessageServerps.def /entry:DllMain dlldata.obj MTMessageServer_p.obj MTMessageServer_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del MTMessageServerps.dll
	@del MTMessageServerps.lib
	@del MTMessageServerps.exp
	@del dlldata.obj
	@del MTMessageServer_p.obj
	@del MTMessageServer_i.obj
