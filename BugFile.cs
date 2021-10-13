using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;
using System.Linq;

namespace TicketingMidTerm{
    public class BugFile : TicketFile<Bug>{
    
        //Constructor -- Takes in a file and turns it into a list of bug tickets
        public BugFile(string file){ 
            //Init' stream reader
            sr = new StreamReader(file);
            //Init' the tickets list
            tickets = new List<Bug>();

            //Fill in tickets
            //Take in the first line (title line)
            sr.ReadLine();
            //While there are still tickets in the file...
            while (!sr.EndOfStream){
                //Read a line
                string line = sr.ReadLine();
                //Parse line
                //There are seven sections, separated by a comma
                string[] sections = line.Split(", ");
                //There are an unknown number of watchers, but are separated by a |
                List<string> watchers = sections[6].Split('|').ToList();
                //Make new ticket
                Bug bug = new Bug(sections[0], sections[1], sections[2], sections[3],
                sections[4], sections[5], watchers, sections[7]);
                //Add ticket to list
                tickets.Add(bug);
            }
            //Close the stream
            sr.Close();
        }
    }
}