using System;
namespace TicketingOOP
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            TO DO:
            - Allow User To 
                - View Tickets
                - Add Tickets
                - Erase Tickets
            - USE METHODS
            - Create Ticket Class
            - Create TicketFile Class

            Plan:
            - Create TicketFile object, load in tickets
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
            Console.WriteLine("Hello World!");
        }
    }
}
