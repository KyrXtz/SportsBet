@echo off

setlocal EnableDelayedExpansion

set version=1.0.0

@echo %version%

set pkgid=SportsBet.Shared

dotnet pack -c Release /p:PackageVersion=%version% --include-symbols

dotnet nuget push bin\Release\%pkgid%.%version%.symbols.nupkg -s http://nuget.local/nuget

:end
