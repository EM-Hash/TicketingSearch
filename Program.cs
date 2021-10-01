using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
namespace TicketingOOP
{
    class Program
    {
        //Create static logger to go across all files
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        //Method to view tickets
        void viewTickets(TicketFile ticketFile){
            //for each ticket in viewTicket, 
            //Print it to the console
        }

        //Method to add tickets
        void addTicket(Ticket ticket){

        }
        static void Main(string[] args)
        {
            //Create file path
            string file = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            //Create TicketFile
            TicketFile tickets = new TicketFile(file);

            //Create do-while loop for user to choose what they wanted to do
            Boolean run = true;
            do{
                //Prompt user
                Console.WriteLine("Welcome to the Ticketing Program!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] View Tickets");
                Console.WriteLine("[2] Add Tickets");
                Console.WriteLine("[3] Clear Tickets");
                Console.WriteLine("[4] Quit");
                //Take in user input
                string ans = Console.ReadLine();
                //Use switch statement to decide where to go
                switch(ans){
                    case "1":
                        //If the user selects 1, go to the viewTickets method
                        break;
                    case "2":
                        //If the user selects 2, go to the addTicket method
                        break;
                    case "3":
                        //If the user selects 3, make sure they REALLY want to get rid of all the tickets
                        //If so, erase the file, if not, do nothing
                        break;
                    default:
                        run = false;
                        break;
                }

            } while (run);

            /*
            Plan:
            - Do-While Loop of:
                - Give user menu
                    - Switch that goes to appropriate function
                        - 1.) View Tickets
                            - Print out each line (including header) 
                        - 2.) Add Ticket
                            - Gen' New ID
                            - Ask User For:
                                - Summary
                                - Status
                                - Priority
                                - Submitter
                                - Assigner
                                - Watching
                            - If any section is blank, put in "N/A" instead
                            - Create new Ticket object
                            - Add ticket to list of tickets and ticket file
                        - 3.) Erase Tickets
                            - Make sure user's sure
                                - If they aren't, go back to menu
                                - If they are, clear file
            */
        }
    }
}
