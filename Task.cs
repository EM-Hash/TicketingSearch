using System;

namespace TicketingMidTerm{
    public class Task : Ticket{
        //Along with the other properties, tasks also have a ProjectName and DueDate
        string projectName;
        DateTime dueDate;

        //Constructors
        //Default constructor - no params = do nothing
        public Task(){
            //Do nothing
        }
        //Construcotr with all parameters
        public Task(string id, string summary, string status, 
        string priority, string submitter, string assigner, string[] watching, string projectName, DateTime dueDate){
            this.id = id;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigner = assigner;
            this.watching = watching;
            this.projectName = projectName;
            this.dueDate = dueDate;
        }

        //Methods
        //Override printing method to add in the projectName and dueDate
        public Override string getTicket(){
            //Put in all the values save the watchers
            string ticketLine = $"{id,-11} | {summary,-25} | {priority,-15} | {submitter,-15} | {assigner,-15} | 
            {watching.join(','), -25} | {projectName, -15} | {dueDate, -10: DD/MM/YY}";
            return(ticketLine);
        }
    }
}