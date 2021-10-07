using System;
using System.Collections.Generic;

namespace TicketingMidTerm{
    public class Enhancement : Ticket{
        //Along with the inherited properties, enhancements also have a software, cost, reasoning, and estimate
        public string software{get; set;}
        public double cost{get; set;}
        public string reasoning{get; set;}
        public string estimate{get; set;}

        //Constructor
        public Enhancement(string id, string summary, string status, 
        string priority, string submitter, string assigner, List<string> watching, 
        string software, double cost, string reasoning, string estimate){
            this.id = id;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigner = assigner;
            this.watching = watching;
            this.software = software;
            this.cost = cost;
            this.reasoning = reasoning;
            this.estimate = estimate;
        }

        //Methods
        //Override printing method to add in the software, cost, reasoning, and estimate
        public override string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | {String.Join(',',watching), -25} | {software, -10} | {cost, -5: C2} | {reasoning, -15} | {estimate, -5}";
            return(ticketLine);
        }
    }
}