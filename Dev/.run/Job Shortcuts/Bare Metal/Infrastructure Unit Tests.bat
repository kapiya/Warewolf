mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Dev2.Infrastructure.Tests