mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Warewolf.UI.Tests -Category Merge Variable Conflicts -PreTestRunScript 'StartAs.ps1 -Cleanup -Anonymous -ResourcesPath UITests'