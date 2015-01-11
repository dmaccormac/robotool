@echo off

: ABOUT
: RoboTool 1.0 -- http://go.danmac.co/robotool
: Use Robocopy to replicate a list of directories in a CSV file.
: Parameters: CSV file - Comma Separated Values of SOURCE,DESTINATION paths. One per line.
: Usage: robotool.bat mylist.csv
: Copyright (C) 2015 Dan MacCormac <info@danmac.co>
:
: LICENSE
:    This program is free software: you can redistribute it and/or modify
:    it under the terms of the GNU General Public License as published by
:    the Free Software Foundation, either version 3 of the License, or
:    (at your option) any later version.
:
:    This program is distributed in the hope that it will be useful,
:    but WITHOUT ANY WARRANTY; without even the implied warranty of
:    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
:    GNU General Public License for more details.
:
:    You should have received a copy of the GNU General Public License
:    along with this program.  If not, see <http://www.gnu.org/licenses/>.

: CREDITS
: Drag/Drop filenames with spaces --> http://go.danmac.co/MRoAR

: TODO
: Trim %source% and %dest% of any leading/trailing whitespaces


:vars
set whoami=RoboTool 1.0  http://go.danmac.co/robotool
set robocopy=%windir%\System32\Robocopy.exe
set args=/MIR /L

:init
if "%~1"=="" goto :usage
if "%~1"=="/?" goto :usage
if "%~1"=="-h" goto :usage
if "%~1"=="-help" goto :usage
if "%~1"=="--help" goto :usage


:main
echo %whoami%
echo CSV File: %1
for /F "tokens=1,2 delims=," %%i in ('type %1') do call :process "%%i" "%%j"
goto :finally


:process
set source=%1
set dest=%2
%robocopy% %args% %source% %dest%
goto :EOF


:finally
echo Complete.
pause
goto :EOF


:usage
echo %whoami%
echo Use Robocopy to replicate a list of directories in a CSV file.
echo.
echo Usage: robotool ^<CSV file^>    
echo   CSV file - Comma Separated Values of SOURCE,DESTINATION paths. One per line.
echo.
echo Example: robotool mylist.csv
echo.
echo Sample CSV:
echo C:\Data\Music,D:\Backup\Music
echo C:\Data\Pictures,D:\Backup\Pictures
goto :EOF


