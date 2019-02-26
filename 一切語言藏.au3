#AutoIt3Wrapper_icon=E中.ico

#include <IE.au3>

Const $MB_ICONERROR = 16
Const $MB_ICONNotify = 48

If RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client', 'Install') <> 1 Then
    MsgBox($MB_ICONERROR, 'English MashUpper needs .NET Framework 4.0 Clien Profile', 'Without .NET Framework 4.0 Clien Profile, English MashUpper cannot run.' & @LF & 'Press OK go to download page.')
	_IECreate ("http://www.microsoft.com/downloads/details.aspx?familyid=E5AD0459-CBCC-4B4F-97B6-FB17111CF544")
	MsgBox($MB_ICONNotify, 'English MashUpper needs .NET Framework 4.0 Clien Profile', 'Please download and install [dotNetFx40_Client_x86_x64.exe].')
	Exit 1
EndIf

$AppTitle = 'English MashUpper needs Speech SDK 5.1'
;若SDK或voice TTS(Mary 跟 mike的聲音) 沒裝，則開啟下載頁面
If RegRead('HKEY_LOCAL_MACHINE\Software\Microsoft\Speech\', 'SDK Version') = "" or RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech\Voices\Tokens\MSMary', 'CLSID') = "" Then
    MsgBox($MB_ICONERROR, $AppTitle, 'Without SAPI, English MashUpper cannot speak.' & @LF & 'Press OK to go to download page.')
	_IECreate ("http://www.microsoft.com/downloads/details.aspx?familyid=5E86EC97-40A7-453F-B0EE-6583171B4530&displaylang=en#filelist")
	
	;若兩者都沒裝
	if RegRead('HKEY_LOCAL_MACHINE\Software\Microsoft\Speech\', 'SDK Version') = "" and RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech\Voices\Tokens\MSMary', 'CLSID') = "" then
		MsgBox($MB_ICONNotify, $AppTitle, 'Please download and install [SpeechSDK51.exe] and [Sp5TTIntXP.exe].')
	endif
  
	;若SDK有裝，表示TTS沒裝
	if RegRead('HKEY_LOCAL_MACHINE\Software\Microsoft\Speech\', 'SDK Version') <> "" then
		MsgBox($MB_ICONNotify, $AppTitle, 'Please download and install [Sp5TTIntXP.exe]. ' & @LF & 'It is a voice engine named Mary and Mike.')
	endif
	
	;若TTS有裝，表示SDK沒裝
	If RegRead('HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech\Voices\Tokens\MSMary', 'CLSID') <> "" Then
		MsgBox($MB_ICONNotify, $AppTitle, 'Please download and istall [SpeechSDK51.exe].' & @LF & ' It is a TTS(Text-to-Speech) engine.')
	endif
EndIf

If FileExists(@WindowsDir & '\English MashUpper.lnk') <> 1 Then
	If(MsgBox(1, "Shortcut?", "You run English MashUpper first time, do you want create shortcut in start menu?") = 1) Then
		FileCreateShortcut(@WorkingDir & "\English MashUpper.exe", @DesktopDir & "\English MashUpper.lnk")
		FileCreateShortcut(@WorkingDir & "\English MashUpper.exe", @StartMenuDir & "\English MashUpper.lnk")
		FileCreateShortcut(@WorkingDir & "\English MashUpper.exe", @ProgramsDir & "\English MashUpper.lnk")
	EndIf
	FileCreateShortcut(@WorkingDir & "\English MashUpper.exe", @WindowsDir & "\English MashUpper.lnk")
EndIf
Exit Run('English MashUpper.dll')