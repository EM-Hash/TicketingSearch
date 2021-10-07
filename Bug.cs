using System;

namespace TicketingMidTerm{
    public class Bug : Ticket{
        //Along with the inherited properties, bugs also have Severity
        string severity;

        //Override printing method to add in severity
        public Override string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | 
            {watching.join(','), -25} | {severity, -10}";
            return(ticketLine);
        }
    }
}