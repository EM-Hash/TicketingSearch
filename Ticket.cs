using System;
using System.Collections.Generic;

namespace TicketingMidTerm{
    public abstract class Ticket{
        //Values w/ getters
        public string id {get;set;}
        public string summary {get;set;}
        public string status {get;set;}
        public string priority {get;set;}
        public string submitter {get;set;}
        public string assigner {get;set;}
        public List<string> watching {get;set;}

        //Constructors 

        //Constructor for no arguments passed in
        public Ticket(){
            //Do nothing, it's just made now
        }

        //Constructor for when all arguments are given
        public Ticket(string id, string summary, string status, 
        string priority, string submitter, string assigner, List<string> watching){
            this.id = id;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigner = assigner;
            this.watching = watching;
        }

        //Method for printing ticket
        public virtual string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | {String.Join(',',watching), -15}";
            return(ticketLine);
        }
    }
}