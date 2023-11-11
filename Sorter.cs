using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    public class Sorter
    {
        // Properties for the base path and log folder path
        public string BasePath { get; set; }
        public string LogFolderPath { get; set; }

        // Entry point for sorting files
        public void Start()
        {
            // CheckFolders instance to validate folders
            CheckFolders checkFolders = new CheckFolders();
            checkFolders.Check(this); // Passes the current Sorter instance
            CheckFiles();
        }

        // Method to check and sort files in the base path
        public void CheckFiles()
        {
            // Get file information in the specified directory
            DirectoryInfo directory = new DirectoryInfo(BasePath);
            FileInfo[] files = directory.GetFiles();

            // Loop through each file
            foreach (FileInfo file in files)
            {
                string fileExtension = file.Extension.ToLower();

                // Check if the file extension is allowed
                if (CheckFolders.AllowedFileExtensions.Any(ext => string.Equals(ext, fileExtension, StringComparison.OrdinalIgnoreCase)))
                {
                    // Create target folder path based on file extension
                    string targetFolderName = fileExtension.TrimStart('.');
                    string targetFolderPath = Path.Combine(BasePath, "Sorted", targetFolderName);

                    // Create target folder if it doesn't exist
                    if (!Directory.Exists(targetFolderPath))
                    {
                        Directory.CreateDirectory(targetFolderPath);
                    }

                    // Move the file to the target folder
                    string targetFilePath = Path.Combine(targetFolderPath, file.Name);
                    try
                    {
                        file.MoveTo(targetFilePath);
                        LogAction($"File '{file.Name}' moved to '{targetFolderPath}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error moving file: {ex.Message}");
                        LogAction($"Error moving file: {ex.Message}", true);
                    }
                }
                else
                {
                    Console.WriteLine($"File '{file.Name}' has an disallowed extension '{fileExtension}'.");
                }
            }

            // After sorting files, create or update the log.txt file in the Log folder
            LogAction("Sorting completed.");
        }

        // Log an action with an optional flag for errors
        private void LogAction(string action, bool isError = false)
        {
            string logFilePath = Path.Combine(LogFolderPath, $"log-{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            try
            {
                // Append action to the log file
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    if (isError)
                    {
                        sw.WriteLine($"ERROR: {DateTime.Now} - {action}");
                    }
                    else
                    {
                        sw.WriteLine($"{DateTime.Now} - {action}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging action: {ex.Message}");
            }
        }
    }
}