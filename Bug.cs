using System;
using System.Collections.Generic;

namespace TicketingMidTerm{
    public class Bug : Ticket{
        //Along with the inherited properties, bugs also have Severity
        public string severity{get; set;}

        //Constructor
        public Bug(string id, string summary, string status, 
        string priority, string submitter, string assigner, List<string> watching, string severity){
            this.id = id;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigner = assigner;
            this.watching = watching;
            this.severity = severity;
        }

        //Override printing method to add in severity
        public override string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | {String.Join(',',watching), -25} | {severity, -10}";
            return(ticketLine);
        }
    }
}