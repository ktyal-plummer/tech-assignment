namespace TechAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string? userInput = "";
            string? fileDirectory = "";

            // Starting prompts 
            Console.WriteLine("- Email Validator -");
            Console.WriteLine("quit/q - quit");
            Console.WriteLine("set/s  - set searching directory");

            // Main loop
            while (true)
            {
                // Get the searching directory from user
                if (fileDirectory == "" || fileDirectory == null)
                {
                    Console.WriteLine();
                    Console.Write("Please enter a valid directory to search: ");
                    fileDirectory = Console.ReadLine();
                    if (fileDirectory == "q" || fileDirectory == "quit")
                    {
                        break;
                    }
                }

                // TODO: remove starting/ending whitespace from userinput
                // Get user input and check if it's a command or file name
                Console.WriteLine();
                Console.Write("Please enter a valid file name: ");
                userInput = Console.ReadLine();

                if (userInput == "set" || userInput == "s")
                {
                    fileDirectory = "";
                }
                else if (userInput == "q" || userInput == "quit")
                {
                    break;
                }
                else
                {
                    // Check if the user added the '.csv' to the end of their file search
                    userInput = FileManager.addFileExtension(userInput);

                    if (FileManager.canFindFile(userInput, fileDirectory))
                    {
                        string fileLocation = fileDirectory + "/" + userInput;
                        EmailValidator sortedEmails = FileManager.readFile(fileLocation);
                        List<string> validEmails = sortedEmails.getValidEmails();
                        List<string> invalidEmails = sortedEmails.getInvalidEmails();

                        // Output all valid emails if there are any
                        if (validEmails.Count > 0)
                        {
                            Console.WriteLine("Valid email addresses:");
                            foreach (string email in validEmails)
                            {
                                Console.WriteLine(email);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No valid email addresses found.");
                        }

                        // Output all invalid emails if there are any
                        if (invalidEmails.Count > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid email addresses:");
                            foreach (string email in invalidEmails)
                            {
                                Console.WriteLine(email);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No invalid email addresses found.");
                        }
                    }
                }
            }

            // Closing prompt
            Console.WriteLine("Email Validator - Goodbye");
        }
    }
}