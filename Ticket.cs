using System;
using System.Collections.Generic;

namespace TicketingOOP{
    public class Ticket{
        //Values w/ getters
        string id {get;}
        string summary {get;}
        string status {get;}
        string priority {get;}
        string submitter {get;}
        string assigner {get;}
        string[] watching {get;}

        //Constructors 

        //Constructor for no arguments passed in
        public Ticket(){
            //Do nothing, it's just made now
        }

        //Constructor for when all arguments are given
        public Ticket(string id, string summary, string status, 
        string priority, string submitter, string assigner, string[] watching){
            this.id = id;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigner = assigner;
            this.watching = watching;
        }

        //Method for printing ticket
        public string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | ";
            //For each watcher, save for the last one
            for (int i = 0; i < watching.Length - 1; i++){
                //Append the watcher to the ticketLine
                ticketLine += watching[i] + ", ";
            }
            //Add on the last watcher
            ticketLine += watching[watching.Length - 1];
            return(ticketLine);
        }

        //Method for returning the ID
        public string getID(){
            return id;
        }
    }
}