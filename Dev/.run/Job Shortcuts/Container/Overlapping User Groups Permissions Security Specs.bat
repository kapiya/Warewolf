powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\..\..\..\Compile.ps1" -AcceptanceTesting -InDockerContainer
mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Dev2.*.Specs,Warewolf.*.Specs -ExcludeProjects Dev2.Activities.Specs,Warewolf.Tools.Specs,Warewolf.UI.Specs,Warewolf.UI.Load.Specs -Category OverlappingUserGroupsPermissionsSecurity -PreTestRunScript "StartAs.ps1 -Cleanup -Anonymous -ResourcesPath ServerTests" -RunInDocker