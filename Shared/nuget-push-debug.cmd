@echo off

setlocal EnableDelayedExpansion

:: Check WMIC is available
WMIC.EXE Alias /? >NUL 2>&1 || GOTO s_error

:: Use WMIC to retrieve date and time
FOR /F "skip=1 tokens=1-6" %%G IN ('WMIC Path Win32_LocalTime Get Day^,Hour^,Minute^,Month^,Second^,Year /Format:table') DO (
   IF "%%~L"=="" goto s_done
      Set _yyyy=%%L
      Set _mm=00%%J
      Set _dd=00%%G
      Set _hour=00%%H
      SET _minute=00%%I
      SET _second=00%%K
)
:s_done

:: Pad digits with leading zeros
Set _mm=%_mm:~-1%
Set _dd=%_dd:~-1%
Set _hour=%_hour:~-2%
Set _minute=%_minute:~-2%
Set _second=%_second:~-2%

Set version=%_yyyy%.%_mm%.%_dd%-beta%_hour%%_minute%

if %version%=="" (
  echo Could not parse system datetime!
  goto :end
)

@echo %version%

set pkgid=SportsBet.Shared
set pkgname=%pkgid%.%version%

@echo %pkgname%|clip

dotnet pack -c Debug /p:PackageVersion=%version% --include-symbols

dotnet nuget push bin\Debug\%pkgname%.symbols.nupkg -s http://nuget.local/nuget

:end