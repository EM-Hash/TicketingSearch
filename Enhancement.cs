using System;

namespace TicketingMidTerm{
    public class Enhancement : Ticket{
        //Along with the inherited properties, enhancements also have a software, cost, reasoning, and estimate
        string software;
        double cost;
        string reasoning;
        string estimate;

        //Constructor
        public Enhancement(){

        }

        //Methods
        //Override printing method to add in the software, cost, reasoning, and estimate
        public Override string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | 
            {watching.join(','), -25} | {software, -10} | {cost, -5: C2} | {reasoning, -15} | {estimate | -5}";
            return(ticketLine);
        }
    }
}