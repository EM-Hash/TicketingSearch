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
        static void viewTickets(TicketFile ticketFile){
            //Get TicketFile list
            List<Ticket> tickets = ticketFile.getTickets();
            //for each ticket in the tickets list
            foreach (Ticket t in tickets){
                //Print the ticket
                Console.WriteLine(t.getTicket());
            }
        }

        //Method to add tickets
        static void addTicket(TicketFile ticketFile){
            /* A ticket needs:
            - an ID
            - a summary
            - a status
            - a priority
            - a submitter
            - an assigner
            - watchers
            */
            string id;
            string summary;
            string status;
            string priority;
            string submitter;
            string assigner;
            //For now, create a list of watchers - will convert later on
            List<string> watchers = new List<string>();
            //Generate the ID
            //Ask the user for the...
            //Summary
            //Status
            //Priority
            //Submitter
            //Assigner
            //Watchers
            //For each value, if it's blank, add in "N/A"
            //Create new ticket
            //Add ticket to ticketFile and write to .csv file
        }
        static void Main(string[] args)
        {
            //Create file path
            string file = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            //Create TicketFile
            TicketFile ticketFile = new TicketFile(file);

            //Create do-while loop for user to choose what they want to do
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
                        viewTickets(ticketFile);
                        break;
                    case "2":
                        //If the user selects 2, go to the addTicket method
                        addTicket(ticketFile);
                        break;
                    case "3":
                        //If the user selects 3, make sure they REALLY want to get rid of all the tickets
                        Console.WriteLine();
                        Console.WriteLine("Delete all tickets? (Note: This CANNOT be undone) [Y/N]: ");
                        string choice = Console.ReadLine();
                        //If so, erase the file, if not, do nothing
                        if (choice[0] == 'Y' || choice[0] == 'y'){
                            //Erase the file
                            StreamWriter sw = new StreamWriter(file);
                            //Write in the header line
                            sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                            //Close the stream writer
                            sw.Close();
                        }
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
