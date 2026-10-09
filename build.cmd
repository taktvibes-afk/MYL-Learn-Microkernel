@echo off
setlocal
cd /d "%~dp0"
where msbuild >nul 2>nul
if errorlevel 1 (
    echo MSBuild nicht gefunden.
    echo Bitte "Developer Command Prompt for VS 2019" starten
    echo und build.cmd erneut ausfuehren.
    exit /b 1
)
msbuild "MYL.LearnMicrokernel.sln" /m /p:Configuration=Release /p:Platform="Any CPU" /verbosity:minimal
if errorlevel 1 exit /b 1
echo.
echo Fertig: MYL.LearnMicrokernel\bin\Release\MYL.LearnMicrokernel.exe
