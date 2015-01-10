## About
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


## Overview
RoboTool is a batch file which uses Microsoft Robocopy to replicate a list of directories in a CSV file.

## Usage
Usage: robotool  <CSV file>
  CSV file - Comma Separated Values of SOURCE,DESTINATION paths. One per line.

### Sample CSV:

The following sample would replicate Music and Pictures folders from C:\Data to D:\Backup

	C:\Data\Music,D:\Backup\Music
	C:\Data\Pictures,D:\Backup\Pictures

### Examples:

	robotool mylist.csv 
	robotool *.csv

RoboTool can be ran from the command line or by dropping a CSV file onto the robotool batch file in Windows.

## Configuration

The following variables can be configured in the section labelled :vars 
Default options are shown below. See Robocopy help for more options.

### Setting Options

	set robocopy=%windir%\System32\Robocopy.exe
	set args=/MIR


## Notes

A General Warning...
While this file has been tested, please keep in mind that Robocopy can delete data and things can go wrong!
The /MIRror option is turned on by default which DELETES any files on DESTINATION that are not in the SOURCE.
Using the /L (list only -- do not copy) option first may be wise until you're sure everything looks right.
See CONFIGURATION section above for setting options.

A note about Drag/Drop....
Drag/Drop with batch files is known to cause issues with certain file names (special chars).
Most file names should work fine (including those with spaces).
Dropping multiple CSV files in not supported. 



