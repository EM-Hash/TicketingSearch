using System;

namespace TicketingOOP{
    public class Ticket{
        //Values w/ getters
        int id {get;}
        string summary {get;}
        string status {get;}
        string priority {get;}
        string submitter {get;}
        string assigner {get;}
        string watching {get;}

        //Constructors 

        //Constructor for no arguments passed in
        public Ticket(){
            //Do nothing, it's just made now
        }

        //Constructor for when all arguments are given
        public Ticket(int id, string summary, string status, 
        string priority, string submitter, string assigner, string watching){
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
            return($"{id,-3} | {summary,-25} | {priority,-7} | {submitter,-15} | {assigner,-15} {watching, -30}");
        }
    }
}