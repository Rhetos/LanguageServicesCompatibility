SETLOCAL

@REM Assuming Build.bat has completed successfully.
test\TestApp\bin\Rhetos.exe dbupdate || GOTO Error0

CALL Tools\Build\FindVisualStudio.bat || GOTO Error0
vstest.console.exe test\Rhetos.LanguageServicesCompatibility.Test\bin\Debug\net5.0\Rhetos.LanguageServicesCompatibility.Test.dll || GOTO Error0

@REM ================================================

@ECHO.
@ECHO %~nx0 SUCCESSFULLY COMPLETED.
@EXIT /B 0

:Error0
@ECHO.
@ECHO %~nx0 FAILED.
@EXIT /B 1
