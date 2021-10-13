using System;
using System.IO;
using NLog.Web;
using System.Collections.Generic;
namespace TicketingMidTerm
{
    class Program
    {
        //Create static logger to go across all files
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        
        //Create TicketFile -- will be initialized with different file path / File class, based on user choice
        static dynamic ticketFile = null;

        //Method to view tickets
        static void viewTickets<T>() where T : Ticket{
            //Get BugFile list
            List<T> tickets = ticketFile.getTickets();
            //for each ticket in the tickets list
            foreach (T t in tickets){
                //Print the ticket
                Console.WriteLine(t.getTicket());
            }
        }
        //Method to add tickets for Bug Files
        static void addTicket(BugFile bugFile, string file){
            /* A bug ticket needs:
            - an ID
            - a summary
            - a status
            - a priority
            - a submitter
            - an assigner
            - watchers
            - a severity
            */
            int id;
            string summary;
            string status;
            string priority;
            string submitter;
            string assigner;
            string severity;
            //For now, create a list of watchers - will convert later on
            List<string> watchers = new List<string>();
            //Generate the ID
            //Take the value of the ID of the last ticket in BugFile and add 1
            //To do this, first take in the last ID as an int
            if (!Int32.TryParse(bugFile.lastID(),out id)){
                //If it can't be an int, then start at 0
                id = 0;
            }
            //Add to the id
            id += 1;
            //Convert the id to a string
            string tempID = id.ToString();

            //Ask the user for the...
            //Summary
            summary = getValue("summary");
            //Status
            status = getValue("status");
            //Priority
            priority = getValue("priority");
            //Submitter
            submitter = getValue("submitter");
            //Assigner
            assigner = getValue("assigner");
            //Watchers
            bool addWatcher = true;
            do{
                //Until the user is done adding watchers
                //Prompt the user to add a watcher
                watchers.Add(getValue("next watcher"));
                //Check if the user would like to add another watcher
                Console.WriteLine("Add another watcher? [Y/N]: ");
                string ans = Console.ReadLine();
                if (ans.ToLower()[0] == 'y'){
                    //If the user wants to keep going, the boolean will stay true
                    addWatcher = true;
                } else {
                    //Else, it will be false, and the loop will break
                    addWatcher = false;
                }
            } while (addWatcher);
            //Severity
            severity = getValue("severity");
            //Create new Bug Ticket
            Bug newBug = new Bug(tempID, summary, status, priority, submitter, 
            assigner, watchers, severity);
            //Add ticket to BugFile and write to .csv file
            bugFile.addTicket(newBug);
            //Create a new streamwriter
            StreamWriter sw = new StreamWriter(file, true);
            //Create the string to write in, add in values
            string fileTicket = $"{id}, {summary}, {status}, {priority}, {submitter}, {assigner}, {string.Join("|",watchers.ToArray())}, {severity}";
            //Write in the ticket
            sw.WriteLine(fileTicket);
            //Close the writer
            sw.Close();
            //Return to main method
        }
        
        //Method to add tickets for Enhancement Files
        static void addTicket(EnhancementFile enhanceFile, string file){
            /* An ehnancement ticket needs:
            - an ID
            - a summary
            - a status
            - a priority
            - a submitter
            - an assigner
            - watchers
            - a software
            - a cost
            - a reason
            - an estimate
            */
            int id;
            string summary;
            string status;
            string priority;
            string submitter;
            string assigner;
            string software;
            double cost;
            string reasoning;
            string estimate;
            //For now, create a list of watchers - will convert later on
            List<string> watchers = new List<string>();
            //Generate the ID
            //Take the value of the ID of the last ticket in BugFile and add 1
            //To do this, first take in the last ID as an int
            if (!Int32.TryParse(enhanceFile.lastID(),out id)){
                //If it can't be an int, then start at 0
                id = 0;
            }
            //Add to the id
            id += 1;
            //Convert the id to a string
            string tempID = id.ToString();

            //Ask the user for the...
            //Summary
            summary = getValue("summary");
            //Status
            status = getValue("status");
            //Priority
            priority = getValue("priority");
            //Submitter
            submitter = getValue("submitter");
            //Assigner
            assigner = getValue("assigner");
            //Watchers
            bool addWatcher = true;
            do{
                //Until the user is done adding watchers
                //Prompt the user to add a watcher
                watchers.Add(getValue("next watcher"));
                //Check if the user would like to add another watcher
                Console.WriteLine("Add another watcher? [Y/N]: ");
                string ans = Console.ReadLine();
                if (ans.ToLower()[0] == 'y'){
                    //If the user wants to keep going, the boolean will stay true
                    addWatcher = true;
                } else {
                    //Else, it will be false, and the loop will break
                    addWatcher = false;
                }
            } while (addWatcher);
            //Software
            software = getValue("software");
            //Cost - keep going until a valid number is put in
            while(!Double.TryParse(getValue("cost"),out cost)){
                Console.WriteLine("That is not a valid cost. \n");
            }
            //Reason
            reasoning = getValue("reason");
            //Estimate
            estimate = getValue("estimate");
            //Create new Bug Ticket
            Enhancement newEnhancement = new Enhancement(tempID, summary, status, priority, submitter, 
            assigner, watchers, software, cost, reasoning, estimate);
            //Add ticket to BugFile and write to .csv file
            enhanceFile.addTicket(newEnhancement);
            //Create a new streamwriter
            StreamWriter sw = new StreamWriter(file, true);
            //Create the string to write in, add in values
            string fileTicket = $"{id}, {summary}, {status}, {priority}, {submitter}, {assigner}, {string.Join("|",watchers.ToArray())}, {software}, {cost:C2}, {reasoning}, {estimate}";
            //Write in the ticket
            sw.WriteLine(fileTicket);
            //Close the writer
            sw.Close();
            //Return to main method
        }
        //Method to add tickets for Task Files
        static void addTicket(TaskFile taskFile, string file){
            /* A bug ticket needs:
            - an ID
            - a summary
            - a status
            - a priority
            - a submitter
            - an assigner
            - watchers
            - a project name
            - a due date
            */
            int id;
            string summary;
            string status;
            string priority;
            string submitter;
            string assigner;
            string projectName;
            DateTime dueDate;
            //For now, create a list of watchers - will convert later on
            List<string> watchers = new List<string>();
            //Generate the ID
            //Take the value of the ID of the last ticket in BugFile and add 1
            //To do this, first take in the last ID as an int
            if (!Int32.TryParse(taskFile.lastID(),out id)){
                //If it can't be an int, then start at 0
                id = 0;
            }
            //Add to the id
            id += 1;
            //Convert the id to a string
            string tempID = id.ToString();

            //Ask the user for the...
            //Summary
            summary = getValue("summary");
            //Status
            status = getValue("status");
            //Priority
            priority = getValue("priority");
            //Submitter
            submitter = getValue("submitter");
            //Assigner
            assigner = getValue("assigner");
            //Watchers
            bool addWatcher = true;
            do{
                //Until the user is done adding watchers
                //Prompt the user to add a watcher
                watchers.Add(getValue("next watcher"));
                //Check if the user would like to add another watcher
                Console.WriteLine("Add another watcher? [Y/N]: ");
                string ans = Console.ReadLine();
                if (ans.ToLower()[0] == 'y'){
                    //If the user wants to keep going, the boolean will stay true
                    addWatcher = true;
                } else {
                    //Else, it will be false, and the loop will break
                    addWatcher = false;
                }
            } while (addWatcher);
            //Project Name
            projectName = getValue("project name");
            //Due Date - keep going until a valid due date is given
            while(!DateTime.TryParse(getValue("due date (MM/DD/YYYY)"), out dueDate)){
                Console.WriteLine("That is not a valid date. \n");
            }
            //Create new Bug Ticket
            Task newTask = new Task(tempID, summary, status, priority, submitter, 
            assigner, watchers, projectName, dueDate);
            //Add ticket to BugFile and write to .csv file
            taskFile.addTicket(newTask);
            //Create a new streamwriter
            StreamWriter sw = new StreamWriter(file, true);
            //Create the string to write in, add in values
            string fileTicket = $"{id}, {summary}, {status}, {priority}, {submitter}, {assigner}, {string.Join("|",watchers.ToArray())}, {projectName}, {dueDate:dd/MM/yyyy}";
            //Write in the ticket
            sw.WriteLine(fileTicket);
            //Close the writer
            sw.Close();
            //Return to main method
        }
        //Method to ask the user for a value, and save it
        static string getValue(string valueName){
            Console.WriteLine($"Please enter the {valueName}: ");
            string value = Console.ReadLine();
            if (value == "" || value == " "){
                return "N/A";
            } else {
                return value;
            }
        }
        static void Main(string[] args)
        {
            //Create file path to the bugs sheet
            string bugPath = Directory.GetCurrentDirectory() + "\\Bugs.csv";
            //Create file path to the enhancement sheet
            string enhancementPath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
            //Create file path to the tasks sheet
            string taskPath = Directory.GetCurrentDirectory() + "\\Tasks.csv";
            //The ticket path used
            string ticketPath = null;

            //Create do-while loop for user to choose what they want to do
            bool run = true;
            do{
                //The type of file the user wants to make
                string fileAns;
                //Prompt user
                Console.WriteLine("Welcome to the Ticketing Program!");
                //Ask which file the user wants to work with
                bool fileLoop = true;
                //While the user is still deciding...
                do {
                    //Ask the user which file they want to work wtih
                    Console.WriteLine("Which file would you like to work with?");
                    Console.WriteLine("[1] Bugs/Defects File");
                    Console.WriteLine("[2] Enhancements File");
                    Console.WriteLine("[3] Tasks File");
                    //Take in the user's answer
                    fileAns = Console.ReadLine();
                    //Create a switch based on what number the user puts in
                    switch(fileAns){
                        case "1":
                            //If the user selects one, create the BugFile with the Bugs path, and set the ticketType to Bug
                            ticketFile = new BugFile(bugPath);
                            ticketPath = bugPath;
                            fileLoop = false;
                            break;
                        case "2":
                            //If the user selects two, create the EnhancementFile with the Enhancements path, and set the
                            //ticketType to Enhancement
                            ticketFile = new EnhancementFile(enhancementPath);
                            ticketPath = enhancementPath;
                            fileLoop = false;
                            break;
                        case "3":
                            //If the user selects three, create the TaskFile with the Tasks path, and se the ticketType
                            //to Task
                            ticketFile = new TaskFile(taskPath);
                            ticketPath = taskPath;
                            fileLoop = false;
                            break;
                        default:
                            //Tell the user it's an improper answer and have them repeat the loop
                            Console.WriteLine("That is not a valid input. \n");
                            break;
                    }
                } while (fileLoop);
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
                        //To decide which type to use in the viewTickets method, use the fileAns
                        switch(fileAns){
                            case "1":
                                //If the user answered 1, use the bug type
                                viewTickets<Bug>();
                                break;
                            case "2":
                                //If the user answered 2, use the Enhancement type
                                viewTickets<Enhancement>();
                                break;
                            case "3":
                                //If the user ansewred 3, use the Task type
                                viewTickets<Task>();
                                break;
                        }
                        break;
                    case "2":
                        //If the user selects 2, go to the addTicket method
                        addTicket(ticketFile, ticketPath);
                        break;
                    case "3":
                        // //If the user selects 3, make sure they REALLY want to get rid of all the tickets
                        // Console.WriteLine();
                        // Console.WriteLine("Delete all tickets? (Note: This CANNOT be undone) [Y/N]: ");
                        // string choice = Console.ReadLine();
                        // //If so, erase the file, if not, do nothing
                        // if (choice[0] == 'Y' || choice[0] == 'y'){
                        //     //Erase the file
                        //     StreamWriter sw = new StreamWriter(ticketPath);
                        //     //Write in the header line
                        //     sw.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                        //     //Close the stream writer
                        //     sw.Close();
                        //     //Rebuild ticket file
                        //     ticketFile = new TicketFile(ticketPath);
                        // }
                        break;
                    default:
                        run = false;
                        break;
                }
            } while (run);
        }
    }
}
