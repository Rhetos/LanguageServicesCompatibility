@REM Starts Visual Studio Developer Command Prompt.
WHERE /Q MSBuild.exe && EXIT /B 0

@REM https://developercommunity.visualstudio.com/content/problem/26780/vsdevcmdbat-changes-the-current-working-directory.html
SET "VSCMD_START_DIR=%CD%"

@REM Using specifically VS2019 (see "-version [16.0,17.0)") to test the build, because Rhetos msbuild integration seems to fail on ResolveRhetosProjectAssets
@REM for VS2022 (Could not load file or assembly 'Newtonsoft.Json, Version=9.0.0.0,...)
FOR /f "usebackq delims=" %%i in (`"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -prerelease -latest -property installationPath -version [16.0^,17.0^)`) do (
  IF EXIST "%%i\Common7\Tools\VsDevCmd.bat" (CALL "%%i\Common7\Tools\VsDevCmd.bat" && GOTO OkRestoreEcho || GOTO Error)
)

:Error
@ECHO ERROR: Cannot find Visual Studio.
@EXIT /B 1
:OkRestoreEcho
@ECHO ON
@ECHO %~nx0 SUCCESSFULLY COMPLETED.
