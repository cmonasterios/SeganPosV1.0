/*
Nombre: SEGANPOS.nsi
Descripcion: Guion de instalacion para SEGAN POS. Creado con NSIS + Advanced logging build
             (http://nsis.sourceforge.net)
Fecha de Creación: 2014-02-04
Autor: Alvaro Carroz
*/

SetCompressor /SOLID lzma
RequestExecutionLevel admin ;Require admin rights on NT6+ (When UAC is turned on)

!include LogicLib.nsh
!include gettime.nsh

!define TEMP1 $R0 ;Temp variable

!define PRODUCT      "SEGAN POS"                                  ## Nombre completo del producto.
!define FILE         "SEGANPOS"                                   ## Nombre corto del producto.
!define COMPANY      "EPK"                                        ## Nombre de la empresa.
!define COMPANY_LONG "EPK"                                        ## Nombre completo de la empresa.
!define SOURCEFOLDER "..\SEGAN Pos"                   ## Carpeta que contiene el resultado de la compilación.
!define MAINEXE      "${SOURCEFOLDER}\bin\Release\SEGANPOS.exe"   ## Ejecutable principal

## Version del .NET Framework requerida.
!define MIN_FRA_MAJOR "4"
!define MIN_FRA_MINOR "5"
!define MIN_FRA_BUILD "*"

!define WWW_MS_DOTNET4_5 "http://msdn.microsoft.com/en-us/library/5a4x27ek.aspx"

Var /GLOBAL usuario

!macro GetPEVersionLocal file defbase
  !verbose push
  !verbose 2
  !tempfile GetPEVersionLocal_nsi
  !tempfile GetPEVersionLocal_exe
  !define GetPEVersionLocal_doll "$"
  !appendfile "${GetPEVersionLocal_nsi}" 'SilentInstall silent$\nRequestExecutionLevel user$\nOutFile "${GetPEVersionLocal_exe}"$\nPage instfiles$\nSection'
  !appendfile "${GetPEVersionLocal_nsi}" '$\nFileOpen $0 "${GetPEVersionLocal_nsi}" w$\nGetDllVersion "${file}" $R0 $R1$\nIntOp $R2 $R0 / 0x00010000$\nIntOp $R3 $R0 & 0x0000FFFF$\nIntOp $R4 $R1 / 0x00010000$\nIntOp $R5 $R1 & 0x0000FFFF'
  !appendfile "${GetPEVersionLocal_nsi}" '$\nFileWrite $0 "!define ${defbase}_1 $R2${GetPEVersionLocal_doll}\n"$\nFileWrite $0 "!define ${defbase}_2 $R3${GetPEVersionLocal_doll}\n"$\nFileWrite $0 "!define ${defbase}_3 $R4${GetPEVersionLocal_doll}\n"$\nFileWrite $0 "!define ${defbase}_4 $R5${GetPEVersionLocal_doll}\n"$\nFileClose $0$\nSectionEnd'
  !system '"${NSISDIR}\makensis" /V2 "${GetPEVersionLocal_nsi}"' = 0
  !system '"${GetPEVersionLocal_exe}"' = 0
  !include "${GetPEVersionLocal_nsi}"
  !delfile "${GetPEVersionLocal_nsi}"
  !delfile "${GetPEVersionLocal_exe}"
  !undef GetPEVersionLocal_nsi
  !undef GetPEVersionLocal_exe
  !undef GetPEVersionLocal_doll
  !verbose pop
!macroend

!insertmacro GetPEVersionLocal "${MAINEXE}" instVer

Name "${PRODUCT} ${instVer_1}.${instVer_2}.${instVer_3}.${instVer_4}"
ShowInstDetails nevershow # show
XPStyle on
LoadLanguageFile "${NSISDIR}\Contrib\Language files\Spanish.nlf"
Icon "${SOURCEFOLDER}\app.ico"

VIAddVersionKey /LANG=${LANG_SPANISH} "ProductName" "${PRODUCT}"
VIAddVersionKey /LANG=${LANG_SPANISH} "CompanyName" "${COMPANY_LONG}"
VIAddVersionKey /LANG=${LANG_SPANISH} "LegalCopyright" "Copyright ©2012 ${COMPANY_LONG}"
VIAddVersionKey /LANG=${LANG_SPANISH} "FileVersion" "${instVer_1}.${instVer_2}.${instVer_3}.${instVer_4}"
VIAddVersionKey /LANG=${LANG_SPANISH} "FileDescription" "${PRODUCT}"
VIProductVersion "${instVer_1}.${instVer_2}.${instVer_3}.${instVer_4}"
# VIAddVersionKey /LANG=${LANG_SPANISH} "Comments" "<comentario>"
# VIAddVersionKey /LANG=${LANG_SPANISH} "LegalTrademarks" "<trademark info>"


## Nombre del ejecutable del instalador.
outfile "Instalador_${FILE}_${instVer_1}.${instVer_2}.${instVer_3}.${instVer_4}.exe"

## Directorio base de destino.
InstallDir "$PROGRAMFILES\${COMPANY}\${PRODUCT}"

Page instfiles


Function .onInit
  # SetSilent silent
  UserInfo::GetName
  Pop $0
  StrCpy $usuario $0

  

  System::Call 'kernel32::CreateMutexA(i 0, i 0, t "F4FEB5D7-4728-4470-AE51-2F97DE4B5C52") i .r1 ?e'
  Pop $R0

  StrCmp $R0 0 +3
    # MessageBox MB_OK|MB_ICONEXCLAMATION "The installer is already running."
    Abort

  InitPluginsDir

  Call CheckAndInstallDotNet
FunctionEnd

Function openLinkNewWindow
  Push $3
  Exch
  Push $2
  Exch
  Push $1
  Exch
  Push $0
  Exch
 
  ReadRegStr $0 HKCR "http\shell\open\command" ""
# Get browser path
    DetailPrint $0
  StrCpy $2 '"'
  StrCpy $1 $0 1
  StrCmp $1 $2 +2 # if path is not enclosed in " look for space as final char
    StrCpy $2 ' '
  StrCpy $3 1
  loop:
    StrCpy $1 $0 1 $3
    DetailPrint $1
    StrCmp $1 $2 found
    StrCmp $1 "" found
    IntOp $3 $3 + 1
    Goto loop
 
  found:
    StrCpy $1 $0 $3
    StrCmp $2 " " +2
      StrCpy $1 '$1"'
 
  Pop $0
  Exec '$1 $0'
  Pop $0
  Pop $1
  Pop $2
  Pop $3
FunctionEnd
 
!macro _OpenURL URL
Push "${URL}"
Call openLinkNewWindow
!macroend
 
!define OpenURL '!insertmacro "_OpenURL"'

Function CheckAndInstallDotNet
    ; Installer dotNetFx45_Full_setup.exe avalible from http://msdn.microsoft.com/en-us/library/5a4x27ek.aspx
    ; Magic numbers from http://msdn.microsoft.com/en-us/library/ee942965.aspx
    ClearErrors
    ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
    IfErrors NotDetected
    ${If} $0 >= 378389
        DetailPrint "Microsoft .NET Framework 4.5 is installed ($0)"
    ${Else}
    NotDetected:
        MessageBox MB_YESNO|MB_ICONQUESTION ".NET Framework 4.5+ is required for ProgramX2013, \
            do you want to launch the web installer? This requires a valid internet connection." IDYES InstallDotNet IDNO Cancel 
        Cancel:
            MessageBox MB_ICONEXCLAMATION "To install ProgramX, Microsoft's .NET Framework v${MIN_FRA_MAJOR}.${MIN_FRA_MINOR} \
                (or higher) must be installed. Cannot proceed with the installation!"
            ${OpenURL} "${WWW_MS_DOTNET4_5}"
            RMDir /r "$INSTDIR" 
            SetOutPath "$PROGRAMFILES"
            RMDir "$INSTDIR" 
            Abort

        ; Install .NET4.5.
        InstallDotNet:
            DetailPrint "Installing Microsoft .NET Framework 4.5"
            SetDetailsPrint listonly
            ExecWait '"$INSTDIR\dotNETFramework\dotNetFx45_Full_setup.exe" /passive /norestart' $0
            ${If} $0 == 3010 
            ${OrIf} $0 == 1641
                DetailPrint "Microsoft .NET Framework 4.5 installer requested reboot."
                SetRebootFlag true 
            ${EndIf}
            SetDetailsPrint lastused
            DetailPrint "Microsoft .NET Framework 4.5 installer returned $0"
    ${EndIf}

    ; Now remove the dotNETFramework directory and contents.
    RMDir /r "$INSTDIR\dotNETFramework" 
FunctionEnd

Function un.DeleteDirIfEmpty
  FindFirst $R0 $R1 "$0\*.*"
  strcmp $R1 "." 0 NoDelete
    FindNext $R0 $R1
    strcmp $R1 ".." 0 NoDelete
      ClearErrors
      FindNext $R0 $R1
      IfErrors 0 NoDelete
        FindClose $R0
        Sleep 1000
        RMDir "$0"
  NoDelete:
    FindClose $R0
FunctionEnd

## Seccion principal.
section
  ${GetTime} "" "L" $0 $1 $2 $3 $4 $5 $6

  setOutPath $INSTDIR
  SetShellVarContext all

  file "${SOURCEFOLDER}\bin\Release\DisplayManager.dll"
  file "${SOURCEFOLDER}\bin\Release\EntityFramework.dll"
  file "${SOURCEFOLDER}\bin\Release\EntityFramework.Extended.dll"
  file "${SOURCEFOLDER}\bin\Release\EntityFramework.SqlServer.dll"
  file "${SOURCEFOLDER}\bin\Release\EPPlus.dll"
  file "${SOURCEFOLDER}\bin\Release\iGreen.Controls.uControls.uLabelX.dll"
  file "${SOURCEFOLDER}\bin\Release\INIFileParser.dll"  
  file "${SOURCEFOLDER}\bin\Release\NLog.dll"
  file "${SOURCEFOLDER}\bin\Release\NLog.EntityFramework.dll"
  file "${SOURCEFOLDER}\bin\Release\NLog.Extended.dll"
  file "${SOURCEFOLDER}\bin\Release\PrinterManager.dll"
  file "${SOURCEFOLDER}\bin\Release\RegularExpressionBuilder.dll"
  file "${SOURCEFOLDER}\bin\Release\System.Linq.Dynamic.dll"
  file "${SOURCEFOLDER}\bin\Release\UserInactivityMonitoring.dll"
      
  file "${MAINEXE}"
  
  SetOverwrite off
  file "${SOURCEFOLDER}\bin\Release\SEGANPOS.exe.config"
  SetOverwrite on
  
  ## Nombre del ejecutable del desinstalador.
  writeUninstaller $INSTDIR\uninstaller.exe
  ## Entradas en Add / Remove Programs.
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "DisplayName" "${PRODUCT}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "UninstallString" "$\"$INSTDIR\uninstaller.exe$\""
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "QuietUninstallString" "$\"$INSTDIR\uninstaller.exe$\" /S"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "DisplayIcon" "$INSTDIR\SEGANPOS.exe,0"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "Publisher" "${COMPANY_LONG}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                   "DisplayVersion" "${instVer_1}.${instVer_2}.${instVer_3}.${instVer_4}"

  WriteRegDWORD  HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                      "NoModify" 0x00000001
  WriteRegDWORD  HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}" \
                      "NoRepair" 0x00000001


  ## Acceso directo en el menu Inicio.
  CreateDirectory "$SMPROGRAMS\${PRODUCT}"
  CreateShortCut "$SMPROGRAMS\${PRODUCT}\SEGAN POS.lnk" "$INSTDIR\SEGANPOS.exe"
  CreateShortCut "$DESKTOP\SEGAN POS.lnk" "$INSTDIR\SEGANPOS.exe"

  ${GetTime} "" "L" $0 $1 $2 $3 $4 $5 $6
  
  
  ExecShell "" "$SMPROGRAMS\${PRODUCT}\SEGAN POS.lnk"
sectionEnd

## Definicion del desinstalador. Siempre debe llamarse "Uninstall".
section "Uninstall"
  SetShellVarContext all

  ## Siempre debe borrarse primero el desinstalador.
  delete $INSTDIR\uninstaller.exe

  ## Luego se borran los archivos instalados.  
  delete $INSTDIR\DisplayManager.dll
  delete $INSTDIR\EntityFramework.dll
  delete $INSTDIR\EntityFramework.Extended.dll
  delete $INSTDIR\EntityFramework.SqlServer.dll
  delete $INSTDIR\EPPlus.dll
  delete $INSTDIR\iGreen.Controls.uControls.uLabelX.dll
  delete $INSTDIR\INIFileParser.dll
  delete $INSTDIR\NLog.dll
  delete $INSTDIR\NLog.EntityFramework.dll
  delete $INSTDIR\NLog.Extended.dll
  delete $INSTDIR\PrinterManager.dll
  delete $INSTDIR\RegularExpressionBuilder.dll
  delete $INSTDIR\System.Linq.Dynamic.dll
  delete $INSTDIR\UserInactivityMonitoring.dll
    
  delete $INSTDIR\SEGANPOS.exe
  delete $INSTDIR\SEGANPOS.exe.config

  delete $INSTDIR\install.log

  ## Se eliminan los accesos directos.
  delete "$SMPROGRAMS\${PRODUCT}\SEGAN POS.lnk"
  delete "$DESKTOP\SEGAN POS.lnk"

  ## Se cambia el directorio actual para poder borrar los directorios de instalación.
  SetOutPath $TEMP

  StrCpy $0 "$INSTDIR"
  Call un.DeleteDirIfEmpty

  StrCpy $0 "$PROGRAMFILES\${PRODUCT}"
  Call un.DeleteDirIfEmpty
  
  StrCpy $0 "$SMPROGRAMS\${PRODUCT}"
  Call un.DeleteDirIfEmpty

  ## Se elimina la entrada de Add / Remove Programs.
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${FILE}"
sectionEnd
