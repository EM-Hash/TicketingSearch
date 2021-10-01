using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;

namespace TicketingOOP{
    public class TicketFile{
        /* 
        Needs a file reader and a list of tickets
        */
        //All the tickets in the file
        List<Ticket> tickets = new List<Ticket>();
        //The stream reader
        StreamReader sr;
        //TicketFile needs a method to print tickets, and a constructor that starts w/ 
        //Reading the file and making the list of tickets

        //Constructor
        public TicketFile(string file){
            //Create a streamreader with the file
            sr = new StreamReader(file);
            //Fill in tickets
            //While there are still tickets in the file...
            while (!sr.EndOfStream){
                //Read a line

                //Parse line

                //Make new ticket
            }
        }

        //Method to print tickets
    }
}