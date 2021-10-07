using System;
namespace TicketingMidTerm{
    public abstract class TicketFile<T>{
        /* 
        Needs a file reader and a list of tickets
        */
        //All the tickets in the file
        List<T> tickets;
        //The stream reader
        StreamReader sr;
        //TicketFile needs a method to print tickets, and a constructor that starts w/ 
        //Reading the file and making the list of tickets

        //Constructor
            //Doesn't do anything - just there to be overriden 
            //This is because each file will have different requirements for separating it, so it will be handled different
            //for each file class
        public virtual ticketFile(){
            tickets = new List<T>();
        }

        //Method to return ticket list
        public List<T> getTickets(){
            return tickets;
        }

        //Method to return the last ticket's ID
        public string lastID(){
            return tickets.Last<T>().getID();
        }

        //Method to add ticket to ticket list
        public void addTicket(T ticket){
            tickets.Add(ticket);
            return;
        }
    }
}