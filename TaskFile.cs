using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketingMidTerm{
    public class TaskFile : TicketFile<Task>{

        //Constructor -- Takes in a file and turns it into a list of task tickets
        public TaskFile(string file){
                //Init' the Stream Reader
                sr = new StreamReader(file);
                //Init' the tickets list
                tickets = new List<Task>();     

                //Fill in tickets
                //Take in the first line (title line)
                sr.ReadLine();
                //While there are still tickets in the file...
                while (!sr.EndOfStream){
                    //Read a line
                    string line = sr.ReadLine();
                    //Parse line - there are 9 sections, separated by commas
                    string[] sections = line.Split(',');
                    //There's an unknown number of watchers, separated by a |
                    List<string> watchers = sections[6].Split('|').ToList();
                    //Make a new ticket
                    Task task = new Task(sections[0], sections[1], sections[2], sections[3], sections [4], sections[5],
                    watchers, sections[7], DateTime.Parse(sections[8]));
                    //Add ticket to list
                    tickets.Add(task);
                }     
                //Close the stream reader
                sr.Close();
        }
        
    }
}