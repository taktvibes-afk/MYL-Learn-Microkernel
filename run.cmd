@echo off
setlocal
cd /d "%~dp0"
if exist "MYL.LearnMicrokernel\bin\Release\MYL.LearnMicrokernel.exe" goto RELEASE
if exist "MYL.LearnMicrokernel\bin\Debug\MYL.LearnMicrokernel.exe" goto DEBUG
echo Kein EXE vorhanden: Erst in Visual Studio die gesamte Projektmappe erstellen.
exit /b 1

:RELEASE
"MYL.LearnMicrokernel\bin\Release\MYL.LearnMicrokernel.exe"
exit /b %errorlevel%

:DEBUG
"MYL.LearnMicrokernel\bin\Debug\MYL.LearnMicrokernel.exe"
exit /b %errorlevel%
