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

        /* About: Test implementation of the 'Backup' class using Microsoft Robcopy.
         * Parameters: CSV file(s) with list of SOURCE,DEST paths must be passed to program on startup. 
         * Backup items are created for each SOURCE,DEST item in the CSV file(s) and each backup item is then started. 
         * A summary is displayed when complete.
         * */



        static int Main(string[] args) //Takes path to CSV file as parameter
        {
            string Description = @"Robotool 1.2 http://go.danmac.co/robotool";
            string Command = "Robocopy.exe";
            string Parameters = "/MIR";
            string Filename = "";

            Console.WriteLine(Description);

            if (args.Length == 1) //single filename as parameter
            {
               if (args[0] == "/?")
               {
                   Usage();
                   return(1);
               }

              
               else
               {
                   Filename = args[0];
                   DoBackup(Command, Parameters, Filename);
                   return (0);
               }
                  
            }


            else if (args.Length >= 2) //multiple filenames
            {

                for (int i = 0; i < args.Length; i++)
                {
                    Filename = args[i];
                    DoBackup(Command, Parameters, Filename);
                }

                return (0);
            }


            else // no args
            {
                
                Usage();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey(true);
                return (-1);
            }


        }


        static bool DoBackup(string Command, string Parameters, string Filename)
        {

            //Create Lists for Source and Dest strings
            List<string> Source = new List<string>();
            List<string> Dest = new List<string>();

            //StreamReader for CSV file
            StreamReader reader = null;

            //Create List of 'Backup' items. 
            List<Backup> Backups = new List<Backup>();




            //Open CSV file
            try
            {
                Console.Write("Open " + Filename + "....");
                reader = new StreamReader(File.OpenRead(Filename)); //Open

            }

            catch (Exception e)
            {
                Console.WriteLine("There was a problem opening the CSV file.\nException Details:\n\n" + e.ToString());
                return (false);

            }



            //Process CSV file
            try 
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != "")
                    {
                        var values = line.Split(',');
                        Source.Add(values[0].Trim());
                        Dest.Add(values[1].Trim());
                    }

                }//end while
                reader.Close();

                Console.WriteLine("[OK]");



            }//end try

            catch (Exception e)
            {
                Console.WriteLine("There was a problem processing the CSV file.\nException Details:\n\n" + e.ToString());
                return (false);
            }


            
            //Populate each item in Backup List.
            for (int i = 0; i < Source.Count; i++)
            {
                Backups.Add(new Backup(Command, Parameters, Source[i], Dest[i]));

            }

            //Start each backup
            Console.WriteLine("Starting " + Backups.Count + " Backup Items...");
            foreach (Backup b in Backups)
                b.Start();

            //Summary on exit
            Console.WriteLine("\n\nProcessed " + Backups.Count + " backup items (" + Filename + ")");

            return (true); 

            
        }

        static void Usage()
        {

            string usage = "Use Robocopy to replicate a list of directories in a CSV file."
                            + "\n\nUsage: robotool.exe <CSV file(s)>"
                            + "\n\tCSV file(s) - Comma Separated Values of SOURCE,DEST paths. One per line."
                            + "\n\nExample: robotool.exe mylist.csv"
                            + "\n\nSample CSV:"
                            + "\n" + @"C:\Data\Music,D:\Backup\Music"
                            + "\n" + @"C:\Data\Pictures,D:\Backup\Pictures";

            Console.WriteLine(usage);


        }



    
    
    }
}
