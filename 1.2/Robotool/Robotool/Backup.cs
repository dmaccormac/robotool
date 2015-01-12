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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Robotool
{
    class Backup
    {
        /* Class: Backup
         * Info: This class can be used to backup files and folders using a backup tool of users choice. It was designed with Microsoft Robocopy in mind.
         * Constructor: 4 Parameters - 
         *                  Command: Full path to backup executable eg robocopy, xcopy etc,
         *                  Parameters: Any optional parameters you wish to pass to the executable specified in 'Command' above.
         *                  Source: Source file or folder, full path.
         *                  Dest: Destintation/Target file or folder, full path
         *                  
         * Data Members: 
         *                  Command (string)
         *                  Parameters (string)
         *                  Source  (string)
         *                  Dest  (string)
         *                  
         * 
         * Methods:
         *                  Start() - start backup job
         *                  Describe() - return job info
         * */



        //Data Members
        private string Command;
        private string Parameters;
        
        public string Source { get; private set; }
        public string Dest { get; private set; }

     
        //Constructor
        public Backup(string Command, string Parameters, string Source, string Dest)
        {
            this.Command = Command;
            this.Parameters = Parameters;
            this.Source = Source;
            this.Dest = Dest;

        }


        /** 
         * Method Name: Start()
         * Description: Use Process.Start() to execute backup job
         * Parameters: none
         * Returns: Bool - result of Process.Start
         * */
        public bool Start()
        {
            bool result;


            var p = new Process();
            p.StartInfo = new ProcessStartInfo(Command, Parameters + " \"" + Source + "\" \"" + Dest +"\"") //wrap source & dest in quotes for paths with spaces support
            {
                UseShellExecute = false
            };


            try
            {
                result = p.Start();
                p.WaitForExit();
            }

            catch (Exception e)
            {
               Console.WriteLine("Caught exception: " + e.ToString());
               result = false;
               
            }



            return (result);

        }


        /** 
         * Method Name: Describe()
         * Description: describe this item by returning values of all data members
         * Parameters: none
         * Returns: description string
         * */
        public string Describe()
        {

            return (Command + " " + Parameters + " " + Source + " " + Dest);
        }


    }
}
