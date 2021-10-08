using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicketingMidTerm{
    public abstract class TicketFile<Ticket>{
        /* 
        Needs a file reader and a list of tickets
        */
        //All the tickets in the file
        public List<Ticket> tickets;
        //The stream reader
        public StreamReader sr;
        //TicketFile needs a method to print tickets, and a constructor that starts w/ 
        //Reading the file and making the list of tickets

        //Constructor
        public TicketFile(){
            
        }

        //Method to return ticket list
        public List<Ticket> getTickets(){
            return tickets;
        }

        // //Method to return the last ticket's ID
        // public string lastID(){
        //     return tickets.Last().getID();
        // }

        //Method to add ticket to ticket list
        public void addTicket(Ticket ticket){
            tickets.Add(ticket);
            return;
        }
    }
}