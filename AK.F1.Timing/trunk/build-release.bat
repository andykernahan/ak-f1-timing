@echo off
if "%1" == "" goto BuildDefault
goto BuildTarget

:BuildDefault
%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe src\AK.F1.Timing.msbuild /p:Configuration=Release;BuildType=Release /t:Build
goto End

:BuildTarget
%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe src\AK.F1.Timing.msbuild /p:Configuration=Release;BuildType=Release /t:%*

:End
