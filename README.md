RoboTool -- Use Robocopy to replicate a list of directories in a CSV file.
Copyright (C) 2015 Dan MacCormac <info@danmac.co>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.


---------
OVERVIEW
---------
RoboTool is a batch file which uses Microsoft Robocopy to replicate a list of directories in a CSV file.

------
USAGE
------
Usage: robotool  <CSV file>
  CSV file - Comma Separated Values of SOURCE,DESTINATION paths. One per line.

Sample CSV:
C:\Data\Music,D:\Backup\Music
C:\Data\Pictures,D:\Backup\Pictures

Examples:
robotool mylist.csv 
robotool *.csv

RoboTool can be ran from the command line or by dropping a CSV file onto the robotool batch file in Windows.

-------------
CONFIGURATION
-------------

The following variables can be configured in the section labelled :vars 
Default options are shown below. See Robocopy help for more options.

set robocopy=%windir%\System32\Robocopy.exe
set args=/MIR


------
NOTES
------

A General Warning...
While this file has been tested, please keep in mind that Robocopy can delete data and things can go wrong!
Using the /L (list only -- do not copy) option first may be wise until you're sure everything looks right.
See CONFIGURATION section above for setting options.

A note about Drag/Drop....
Drag/Drop with batch files is known to cause issues with certain file names (special chars).
Most file names should work fine (including those with spaces).
Dropping multiple CSV files in not supported. 



