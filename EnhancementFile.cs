using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingMidTerm{
    public class EnhancementFile : TicketFile<Enhancement>{
        
        //Constructor -- Takes in a file and turns it into a list of enhancement tickets
        public EnhancementFile(string file){
            //Init' the stream reader
            sr = new StreamReader(file);
            //Init' the tickets list
            tickets = new List<Enhancement>();

            //Fill tickets list
            //Take in the first line (not keeping it)
            sr.ReadLine();
            //While there are still tickets...
            while (!sr.EndOfStream){
                //Take in the next line
                string line = sr.ReadLine();
                //Split on the comma; there are 11 sections
                string[] sections = line.Split(',');
                //There's an unknown number of watchers, separating by a | -- They're the seventh section of the line
                List<string> watchers = sections[6].Split('|').ToList();
                //Make new ticket -- the ninth value is a double
                Enhancement enh = new Enhancement(sections[0], sections[1], sections[2], sections[3], sections[4], sections[5],
                watchers, sections[7], Double.Parse(sections[8]), sections[9], sections[10]);
                //Add the ticket to the list
                tickets.Add(enh);
            }
            //Close the stream
            sr.Close();
        }
    }
}