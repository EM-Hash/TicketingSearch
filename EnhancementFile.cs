using System;
using System.Collections.Generic;

namespace TicketingMidTerm{
    public class EnhancementFile : TicketFile<Enhancement>{
        
        //Constructor -- Takes in a file and turns it into a list of enhancement tickets
        public EnhancementFile(string file){
            //Instantiate the tickets list
            tickets = new List<Enhancement>();
        }
    }
}