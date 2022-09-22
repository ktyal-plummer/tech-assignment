using System.Text;

namespace TechAssignment
{
    class FileManager
    {
        /// <summary>
        /// Makes sure a file can be found within a specified directory. Logs error messages to the user 
        /// </summary>
        /// <param name="fileName">The name of the file to search for</param>
        /// <param name="fileDirectory">The directory to search for the file</param>
        /// <returns>Whether or not the file could be found in the directory</returns>
        public static bool canFindFile(string? fileName, string? fileDirectory)
        {
            if (fileName != null && fileDirectory != null)
            {
                // Check to make sure the directory exists 
                if (Directory.Exists(fileDirectory))
                {
                    // Check to make sure there is a file with the correct name in the directory
                    string pathToFile = fileDirectory + "/" + fileName;
                    if (File.Exists(pathToFile))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("<ERROR> No such file '{0}' exsits in directory: '{1}'.", fileName, fileDirectory);
                    }
                }
                else
                {
                    Console.WriteLine("<ERROR> No such directory exsits on path: '{0}'.", fileDirectory);
                }
            }

            return false;
        }

        /// <summary>
        /// Reads through a given file and tries to validate the email addresses
        /// </summary>
        /// <param name="filePath">The path used to get to the file</param>
        /// <returns>A new EmailValidator which will have the lists of sorted emails</returns>
        public static EmailValidator readFile(string filePath)
        {
            EmailValidator validator = new EmailValidator();
            int enrtyNumber = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? currentLine;
                while ((currentLine = reader.ReadLine()) != null) {
                    enrtyNumber++;

                    // Try to find and validate the email, otherwise output an error
                    try {
                        string[] seperatedLine = currentLine.Split(',');
                        string emailToValidate = seperatedLine[2];
                        validator.validate(emailToValidate);

                    } catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("<ERROR> Invalid entry on line: {0}", enrtyNumber);
                    }
                }
            }

            return validator;
        }

        /// <summary>
        /// Makes sure the inputed file name has the correct extension
        /// </summary>
        /// <param name="originalFileName">The user inputed file name</param>
        /// <returns>A file name with a .csv extension or an empty string if null was given</returns>
        public static string addFileExtension(string? originalFileName)
        {
            string? newFileName = originalFileName;
            if (originalFileName != null && newFileName != null)
            {
                if (originalFileName.Length < 4 || originalFileName.Substring(originalFileName.Length - 4) != ".csv")
                {
                    newFileName = newFileName + ".csv";
                }

                return newFileName;
            }   
        
            return "";
        }
    }
}