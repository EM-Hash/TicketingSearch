using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;
using System.Linq;

namespace TicketingOOP{
    public class TicketFile{
        /* 
        Needs a file reader and a list of tickets
        */
        //All the tickets in the file
        List<Ticket> tickets = new List<Ticket>();
        //The stream reader
        StreamReader sr;
        //TicketFile needs a method to print tickets, and a constructor that starts w/ 
        //Reading the file and making the list of tickets

        //Constructor
        public TicketFile(string file){
            //Create a streamreader with the file
            sr = new StreamReader(file);
            //Fill in tickets
            //While there are still tickets in the file...
            while (!sr.EndOfStream){
                //Read a line
                string line = sr.ReadLine();
                //Parse line
                //There are seven sections, separated by a comma
                string[] sections = line.Split(',');
                //There are an unknown number of watchers, but are separated by a |
                string[] watchers = sections[6].Split('|');
                //Make new ticket
                Ticket tempTicket = new Ticket(sections[0], sections[1], sections[2], sections[3],
                sections[4], sections[5], watchers);
                //Add ticket to list
                tickets.Add(tempTicket);
            }
            sr.Close();
        }

        //Method to return ticket list
        public List<Ticket> getTickets(){
            return tickets;
        }

        //Method to return the last ticket's ID
        public string lastID(){
            return tickets.Last<Ticket>().getID();
        }

        //Method to add ticket to ticket list
        public void addTicket(Ticket ticket){
            tickets.Add(ticket);
            return;
        }
    }
}