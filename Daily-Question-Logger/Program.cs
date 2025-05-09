using System;
using System.IO;

namespace Daily_Question_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Save to "My Documents"
            string docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logFilePath = Path.Combine(docsFolder, "daily_log.txt");

            // Asking the Question
            string response = "";
            while (string.IsNullOrEmpty(response))
            {
            Console.WriteLine("What's one thing you learned today?📝 (Cannot be empty)");
            response = Console.ReadLine();

            }

            // Log response with timestamp
            string logEntry = $"{DateTime.Now} : {response}";

            try
            {
             
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                string fullPath = Path.GetFullPath(logFilePath);
                Console.WriteLine($"Success! Log Saved to \n{fullPath}");
                
                Console.WriteLine("\nView previous logs? (y/n)");
                string viewLogs;
                do
                {
                    viewLogs = Console.ReadLine().ToLower();
                    if (viewLogs == "y")
                    {
                        Console.WriteLine("\n--- Past Logs ---");
                        Console.WriteLine(File.ReadAllText(logFilePath));
                    }
                    else if (viewLogs == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'y' or 'n')");
                    }
                } while (true);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }

            Console.WriteLine("Logged! Press any key to exit");
            Console.ReadKey();
        }
    }
}
