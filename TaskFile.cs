using System;

namespace TicketingMidTerm{
    public class TaskFile : TicketFile<Task>{

        //Constructor -- Takes in a file and turns it into a list of task tickets
        public TaskFile(string file){
                //Instantiate the tickets list
                tickets = new List<Task>();           
        }
        
    }
}