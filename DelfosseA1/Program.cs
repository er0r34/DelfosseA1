namespace Delfosse_A1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            do
            {
                Console.WriteLine("1) Read Tickets from file.");
                Console.WriteLine("2) Create Tickets from data.");
                Console.WriteLine("Enter any other key to exit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    //logic to read
                    StreamReader sr = new StreamReader(file);
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string[] arr = line.Split(',');
                        //TicketID,Summary,Status,Priority,Submitter,Assigned,Watching
                        Console.WriteLine($"{arr[0]},{arr[1]},{arr[2]},{arr[3]},{arr[4]},{arr[5]},{arr[6]}");
                    }



                    sr.Close(); //Always close!!
                }
                else if (choice == "2")
                {
                    // logic to write
                    StreamWriter sw = new StreamWriter(file, true);

                    Console.WriteLine("Enter the ticketID");
                    string ticket = Console.ReadLine();

                    Console.WriteLine("Enter the summary.");
                    string summary = Console.ReadLine();

                    Console.WriteLine("Enter the status. (Open, Closed)");
                    string status = Console.ReadLine();

                    Console.WriteLine("Enter the priority level. (High, Medium, or Low)");
                    string priority = Console.ReadLine();

                    Console.WriteLine("Enter the submitter.");
                    string submit = Console.ReadLine();

                    Console.WriteLine("Enter the assigned.");
                    string assign = Console.ReadLine();

                    List<string> watchersArr = new List<string>();

                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine("Enter watcher(s).");
                        watchersArr.Add(Console.ReadLine() + '|');

                        Console.WriteLine("Would you like to add another watcher? (Y/N)");
                        string resp = Console.ReadLine().ToUpper();
                        if (resp != "Y")
                        {
                            watchersArr[i] = watchersArr[i].TrimEnd('|');
                            break;
                        }

                    }



                    string entryLine = $"{ticket},{summary},{status},{priority},{submit},{assign},";

                    foreach (string watcher in watchersArr)
                    {
                        entryLine += watcher;
                    }

                    sw.WriteLine(entryLine);

                    sw.Close(); //Always close!
                }

            } while (choice == "1" || choice == "2");

        }
    }
}