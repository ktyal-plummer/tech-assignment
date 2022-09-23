using System.Text;

namespace TechAssignment
{
    /// <summary>
    /// Contains all methods needed to get to, validate, and read from a file.
    /// </summary>
    class FileManager
    {
        /// <summary>
        /// Checks to make sure the given directory can be found
        /// </summary>
        /// <param name="fileDirectory">The directory being searched for</param>
        /// <returns>Whether or not the directory given was valid</returns>
        public static bool isValidDirectory(string? fileDirectory)
        {
            if (fileDirectory != null)
            {
                if (Directory.Exists(fileDirectory))
                {
                    return true;
                }
                else 
                {
                    Console.WriteLine("<ERROR> No such directory exsits on path: '{0}'.", fileDirectory);
                }
            }
            return false;
        }

        /// <summary>
        /// Used to verify a file can be found on a specified path 
        /// </summary>
        /// <param name="pathToFile">The complete path to the file</param>
        /// <returns>Whether or not the file could be found on the path</returns>
        public static bool isValidFilePath(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                return true;
            }
            else
            {
                Console.WriteLine("<ERROR> No such file exsits on path '{0}'", pathToFile);
            }

            return false;
        }

        /// <summary>
        /// Creates the complete path to a file using its name and target directory
        /// </summary>
        /// <param name="fileName">The given name of the file</param>
        /// <param name="fileDirectory">The directory the file should be located in</param>
        /// <returns>A string containing the complete file path</returns>
        public static string generateFilePath(string fileName, string? fileDirectory)
        {
            string completePath = "";

            if (fileDirectory != null)
            {
                if (fileDirectory.EndsWith('/'))
                {
                    completePath = fileDirectory + fileName;
                }
                else
                {
                    completePath = fileDirectory + "/" + fileName;
                }
            }

            return completePath;
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
                        // CSV was not in the correct format 
                        Console.WriteLine("<ERROR> Invalid entry on line: {0}", enrtyNumber);
                    }
                }
            }

            return validator;
        }

        /// <summary>
        /// Makes sure the inputed file name has the correct extension or adds it
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