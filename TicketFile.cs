using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingMidTerm{
    public abstract class TicketFile<T> where T : Ticket{
        /* 
        Needs a file reader and a list of tickets
        */
        //All the tickets in the file
        public List<T> tickets;
        //The stream reader
        public StreamReader sr;
        //TicketFile needs a method to print tickets, and a constructor that starts w/ 
        //Reading the file and making the list of tickets

        //Constructor
        public TicketFile(){
            //Construct list
            tickets = new List<T>();
        }

        //Method to return ticket list
        public List<T> getTickets(){
            return tickets;
        }

        //Method to return the last ticket's ID
        public string lastID(){
            if(tickets.Count != 0){
                return tickets.Last().id;
            } else {
                return "0";
            }
        }

        //Method to add ticket to ticket list
        public void addTicket(T ticket){
            tickets.Add(ticket);
            return;
        }
    }
}