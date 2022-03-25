SETLOCAL
SET Version=1.1.0
SET Prerelease=auto

@SET Config=%1%
@IF [%1] == [] SET Config=Debug

CALL Tools\Build\FindVisualStudio.bat || GOTO Error0

REM Updating the build version.
PowerShell -ExecutionPolicy ByPass .\tools\Build\ChangeVersion.ps1 %Version% %Prerelease% || GOTO Error0

WHERE /Q NuGet.exe || ECHO ERROR: Please download the NuGet.exe command line tool. && GOTO Error0
NuGet restore LanguageServicesCompatibility.sln -NonInteractive || GOTO Error0
MSBuild LanguageServicesCompatibility.sln /target:rebuild /p:Configuration=Debug /p:RhetosDeploy=false /verbosity:minimal /fileLogger || GOTO Error0

IF NOT EXIST Install MD Install
DEL /F /S /Q Install\* || GOTO Error0
NuGet pack .\src\Rhetos.LanguageServicesCompatibility.nuspec -OutputDirectory Install || GOTO Error0

REM Updating the build version back to "dev" (internal development build), to avoid spamming git history with timestamped prerelease versions.
PowerShell -ExecutionPolicy ByPass .\tools\Build\ChangeVersion.ps1 %Version% dev || GOTO Error0

@REM ================================================

@ECHO.
@ECHO %~nx0 SUCCESSFULLY COMPLETED.
@EXIT /B 0

:Error0
@PowerShell -ExecutionPolicy ByPass .\tools\Build\ChangeVersion.ps1 %Version% dev >nul
@ECHO.
@ECHO %~nx0 FAILED.
@IF /I [%1] NEQ [/NOPAUSE] @PAUSE
@EXIT /B 1
