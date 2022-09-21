namespace TechAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string? userInput = "";
            string? fileDirectory = "";
            bool programRunning = true;

            Console.WriteLine("- Email Validator -");
            Console.WriteLine("q     - quit");
            Console.WriteLine("set/s - set searching directory");

            while (programRunning)
            {
                if (fileDirectory == "" || fileDirectory == null)
                {
                    Console.WriteLine();
                    Console.Write("Please enter a valid directory to search: ");
                    fileDirectory = Console.ReadLine();
                    if (fileDirectory == "q") {
                        break;
                    }
                }
                
                Console.WriteLine();
                Console.Write("Please enter a valid file name: ");
                userInput = Console.ReadLine();

                // TODO: remove starting/ending whitespace from userinput

                if (userInput == "set" || userInput == "s")
                {
                    fileDirectory = "";
                } 
                else if (userInput == "q") {
                    break;
                }
                else {
                    // Check if the user added the '.csv' to the end of their file search
                    userInput = FileManager.addFileExtension(userInput);
                    if (FileManager.canFindFile(userInput, fileDirectory))
                    {
                        string fileLocation = fileDirectory + "/" + userInput;
                        FileManager.readFile(fileLocation);
                    }
                }
            }

            Console.WriteLine("Email Validator - Goodbye");
        }
    }
}