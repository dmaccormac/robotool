/*
 * Robotool -- Use Robocopy to replicate a list of directories in a CSV file.
 * http://go.danmac.co/robotool
 * 
 * Copyright (C) 2015 Dan MacCormac <info@danmac.co>
 * Robotool is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * Robotool is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with Robotool. If not, see http://www.gnu.org/licenses/.
 * 
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Robotool
{

    class Program
    {

        /* Class: Program
         * Info: Test implementation of the 'Backup' class using Microsoft Robcopy.
         * CSV file with list of SOURCE,DEST paths must be passed to Main() method on startup. 
         * A Backup object is then created and started for each SOURCE,DEST entry. 
         * A summary is displayed when program is complete.
         * */



        static int Main(string[] args) //Takes path to CSV file as parameter
        {
            string Description = @"Robotool 1.1 http://go.danmac.co/robotool";
            Console.WriteLine(Description);

            if (args.Length == 1)
            {
               
                string Command = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Robocopy.exe";
                String Parameters = "/MIR";

                //open CSV file
                var reader = new StreamReader(File.OpenRead(args[0])); //args[0] is path to csv file 

                //Create lists for source and dest strings
                List<string> Source = new List<string>();
                List<string> Dest = new List<string>();

                //Parse CSV file
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    if (line != "")
                    {
                        var values = line.Split(',');
                        Source.Add(values[0].Trim());
                        Dest.Add(values[1].Trim());
                    }

                }

                //Create the List of type 'Backup' and populate each item
                List<Backup> Backups = new List<Backup>();

                for (int i = 0; i < Source.Count; i++)
                {
                    Backups.Add(new Backup(Command, Parameters, Source[i], Dest[i]));

                }


                //Start each Backup Item withn Backups
                foreach (Backup b in Backups)
                {
                    b.Start();


                }


                //Summary on exit
                Console.WriteLine("\n"
                    + "\nProcessed total of " + Backups.Count + " backup items."
                    + "\nPress any key to exit...");

                Console.ReadKey(true);
                return (0);


            }

            else
            {
                string usage = "Use Robocopy to replicate a list of directories in a CSV file."
                               + "\n\nUsage: robotool.exe <CSV file>"
                                + "\n\tCSV file - Comma Separated Values of SOURCE,DEST paths. One per line."
                                + "\n\nExample: robotool.exe mylist.csv"
                                + "\n\nSample CSV:"
                                + "\n" + @"C:\Data\Music,D:\Backup\Music"
                                + "\n" + @"C:\Data\Pictures,D:\Backup\Pictures";

                Console.WriteLine(usage);

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey(true);
                return (-1);

            }



        }
    }
}
