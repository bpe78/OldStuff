# Microsoft Developer Studio Generated NMAKE File, Based on X1.dsp
!IF "$(CFG)" == ""
CFG=X1 - Win32 Debug
!MESSAGE No configuration specified. Defaulting to X1 - Win32 Debug.
!ENDIF 

!IF "$(CFG)" != "X1 - Win32 Release" && "$(CFG)" != "X1 - Win32 Debug"
!MESSAGE Invalid configuration "$(CFG)" specified.
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "X1.mak" CFG="X1 - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "X1 - Win32 Release" (based on "Win32 (x86) Application")
!MESSAGE "X1 - Win32 Debug" (based on "Win32 (x86) Application")
!MESSAGE 
!ERROR An invalid configuration is specified.
!ENDIF 

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 

CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "X1 - Win32 Release"

OUTDIR=.\Release
INTDIR=.\Release
# Begin Custom Macros
OutDir=.\Release
# End Custom Macros

ALL : "$(OUTDIR)\X1.exe"


CLEAN :
	-@erase "$(INTDIR)\DoubleButton.obj"
	-@erase "$(INTDIR)\MainFrm.obj"
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\Test.obj"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(INTDIR)\X1.obj"
	-@erase "$(INTDIR)\X1.pch"
	-@erase "$(INTDIR)\X1.res"
	-@erase "$(INTDIR)\X1Doc.obj"
	-@erase "$(INTDIR)\X1View.obj"
	-@erase "$(OUTDIR)\X1.exe"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\X1.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 
MTL_PROJ=/nologo /D "NDEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\X1.res" /d "NDEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\X1.bsc" 
BSC32_SBRS= \
	
LINK32=link.exe
LINK32_FLAGS=/nologo /subsystem:windows /incremental:no /pdb:"$(OUTDIR)\X1.pdb" /machine:I386 /out:"$(OUTDIR)\X1.exe" 
LINK32_OBJS= \
	"$(INTDIR)\X1.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\MainFrm.obj" \
	"$(INTDIR)\X1Doc.obj" \
	"$(INTDIR)\X1View.obj" \
	"$(INTDIR)\X1.res" \
	"$(INTDIR)\Test.obj" \
	"$(INTDIR)\DoubleButton.obj"

"$(OUTDIR)\X1.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"

OUTDIR=.\Debug
INTDIR=.\Debug
# Begin Custom Macros
OutDir=.\Debug
# End Custom Macros

ALL : "$(OUTDIR)\X1.exe" "$(OUTDIR)\X1.bsc"


CLEAN :
	-@erase "$(INTDIR)\DoubleButton.obj"
	-@erase "$(INTDIR)\DoubleButton.sbr"
	-@erase "$(INTDIR)\MainFrm.obj"
	-@erase "$(INTDIR)\MainFrm.sbr"
	-@erase "$(INTDIR)\StdAfx.obj"
	-@erase "$(INTDIR)\StdAfx.sbr"
	-@erase "$(INTDIR)\Test.obj"
	-@erase "$(INTDIR)\Test.sbr"
	-@erase "$(INTDIR)\vc60.idb"
	-@erase "$(INTDIR)\vc60.pdb"
	-@erase "$(INTDIR)\X1.obj"
	-@erase "$(INTDIR)\X1.pch"
	-@erase "$(INTDIR)\X1.res"
	-@erase "$(INTDIR)\X1.sbr"
	-@erase "$(INTDIR)\X1Doc.obj"
	-@erase "$(INTDIR)\X1Doc.sbr"
	-@erase "$(INTDIR)\X1View.obj"
	-@erase "$(INTDIR)\X1View.sbr"
	-@erase "$(OUTDIR)\X1.bsc"
	-@erase "$(OUTDIR)\X1.exe"
	-@erase "$(OUTDIR)\X1.ilk"
	-@erase "$(OUTDIR)\X1.pdb"

"$(OUTDIR)" :
    if not exist "$(OUTDIR)/$(NULL)" mkdir "$(OUTDIR)"

CPP_PROJ=/nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /FR"$(INTDIR)\\" /Fp"$(INTDIR)\X1.pch" /Yu"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /GZ   /c 
MTL_PROJ=/nologo /D "_DEBUG" /mktyplib203 /win32 
RSC_PROJ=/l 0x409 /fo"$(INTDIR)\X1.res" /d "_DEBUG" /d "_AFXDLL" 
BSC32=bscmake.exe
BSC32_FLAGS=/nologo /o"$(OUTDIR)\X1.bsc" 
BSC32_SBRS= \
	"$(INTDIR)\X1.sbr" \
	"$(INTDIR)\StdAfx.sbr" \
	"$(INTDIR)\MainFrm.sbr" \
	"$(INTDIR)\X1Doc.sbr" \
	"$(INTDIR)\X1View.sbr" \
	"$(INTDIR)\Test.sbr" \
	"$(INTDIR)\DoubleButton.sbr"

"$(OUTDIR)\X1.bsc" : "$(OUTDIR)" $(BSC32_SBRS)
    $(BSC32) @<<
  $(BSC32_FLAGS) $(BSC32_SBRS)
<<

LINK32=link.exe
LINK32_FLAGS=/nologo /subsystem:windows /incremental:yes /pdb:"$(OUTDIR)\X1.pdb" /debug /machine:I386 /out:"$(OUTDIR)\X1.exe" /pdbtype:sept 
LINK32_OBJS= \
	"$(INTDIR)\X1.obj" \
	"$(INTDIR)\StdAfx.obj" \
	"$(INTDIR)\MainFrm.obj" \
	"$(INTDIR)\X1Doc.obj" \
	"$(INTDIR)\X1View.obj" \
	"$(INTDIR)\X1.res" \
	"$(INTDIR)\Test.obj" \
	"$(INTDIR)\DoubleButton.obj"

"$(OUTDIR)\X1.exe" : "$(OUTDIR)" $(DEF_FILE) $(LINK32_OBJS)
    $(LINK32) @<<
  $(LINK32_FLAGS) $(LINK32_OBJS)
<<

!ENDIF 

.c{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx{$(INTDIR)}.obj::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.c{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cpp{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<

.cxx{$(INTDIR)}.sbr::
   $(CPP) @<<
   $(CPP_PROJ) $< 
<<


!IF "$(NO_EXTERNAL_DEPS)" != "1"
!IF EXISTS("X1.dep")
!INCLUDE "X1.dep"
!ELSE 
!MESSAGE Warning: cannot find "X1.dep"
!ENDIF 
!ENDIF 


!IF "$(CFG)" == "X1 - Win32 Release" || "$(CFG)" == "X1 - Win32 Debug"
SOURCE=.\DoubleButton.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\DoubleButton.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\DoubleButton.obj"	"$(INTDIR)\DoubleButton.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 

SOURCE=.\MainFrm.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\MainFrm.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\MainFrm.obj"	"$(INTDIR)\MainFrm.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 

SOURCE=.\StdAfx.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"

CPP_SWITCHES=/nologo /MD /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /Fp"$(INTDIR)\X1.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\X1.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"

CPP_SWITCHES=/nologo /MDd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_AFXDLL" /D "_MBCS" /FR"$(INTDIR)\\" /Fp"$(INTDIR)\X1.pch" /Yc"stdafx.h" /Fo"$(INTDIR)\\" /Fd"$(INTDIR)\\" /FD /GZ   /c 

"$(INTDIR)\StdAfx.obj"	"$(INTDIR)\StdAfx.sbr"	"$(INTDIR)\X1.pch" : $(SOURCE) "$(INTDIR)"
	$(CPP) @<<
  $(CPP_SWITCHES) $(SOURCE)
<<


!ENDIF 

SOURCE=.\Test.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\Test.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\Test.obj"	"$(INTDIR)\Test.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 

SOURCE=.\X1.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\X1.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\X1.obj"	"$(INTDIR)\X1.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 

SOURCE=.\X1.rc

"$(INTDIR)\X1.res" : $(SOURCE) "$(INTDIR)"
	$(RSC) $(RSC_PROJ) $(SOURCE)


SOURCE=.\X1Doc.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\X1Doc.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\X1Doc.obj"	"$(INTDIR)\X1Doc.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 

SOURCE=.\X1View.cpp

!IF  "$(CFG)" == "X1 - Win32 Release"


"$(INTDIR)\X1View.obj" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ELSEIF  "$(CFG)" == "X1 - Win32 Debug"


"$(INTDIR)\X1View.obj"	"$(INTDIR)\X1View.sbr" : $(SOURCE) "$(INTDIR)" "$(INTDIR)\X1.pch"


!ENDIF 


!ENDIF 

