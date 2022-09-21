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

        // TODO: Start doing things with the read in lines
        public static void readFile(string filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                Console.WriteLine();
                Console.WriteLine("Validating .. '{0}'", filePath);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

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