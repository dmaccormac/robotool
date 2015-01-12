## About
RoboTool 1.2 -- Use Robocopy to replicate a list of directories in specified CSV file(s).

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
RoboTool is a program to mirror a list of directories specified in one or more CSV files. 
It uses Microsoft Robocopy to replicate the directories. It is written in C# and uses the NET 4.5 framework.

## Usage

	Usage: robotool  <CSV file(s)>
	CSV file(s) - Comma Separated Values of SOURCE,DESTINATION paths. One per line.

### Examples:

	robotool mylist.csv 
	robotool mylist.csv mylist2.csv
	robotool *.csv
	
### Sample CSV:

The following sample would replicate Music and Pictures folders from C:\Data to D:\Backup

	C:\Data\Music,D:\Backup\Music
	C:\Data\Pictures,D:\Backup\Pictures

RoboTool can be ran from the command line or by dropping a CSV file onto the robotool program file.

## Configuration

The following user configurable variables can be set in Program.cs

	string Command = ... "Robocopy.exe";
    String Parameters = "/MIR";

## Notes

### A General Warning
While this file has been tested, please keep in mind that Robocopy can delete data and things can go wrong!
The /MIRror option is turned on by default which DELETES any files on DESTINATION that are not in the SOURCE.






