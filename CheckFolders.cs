using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    public class CheckFolders
    {
        // Array of allowed file extensions
        public static string[] AllowedFileExtensions = {
    ".txt", ".csv", ".xml", ".cs", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
    ".pdf", ".jpg", ".jpeg", ".png", ".mp3", ".mp4", ".avi", ".gif", ".html", ".css",
    ".js", ".json", ".zip", ".rar", ".tar", ".gz", ".7z", ".exe", ".dll", ".jar", ".py",
    ".cpp", ".h", ".java", ".php", ".sql", ".md", ".yaml", ".svg", ".bmp", ".ico", ".tif",
    ".tiff", ".wav", ".ogg", ".flac", ".aac", ".mov", ".wmv", ".flv", ".mkv", ".psd",
    ".ai", ".eps", ".pptm", ".xlsm", ".docm", ".bat", ".sh", ".html", ".xml", ".yml"
    // Füge hier weitere Dateierweiterungen hinzu, wenn nötig
        };


        // Method to check and create necessary folders
        public void Check(Sorter sorter)
        {
            // Set the log folder path
            sorter.LogFolderPath = Path.Combine(sorter.BasePath, "Log");

            // Create the Log folder if it doesn't exist
            if (!Directory.Exists(sorter.LogFolderPath))
            {
                Directory.CreateDirectory(sorter.LogFolderPath);
            }

            // Check if the base folder exists
            if (!Directory.Exists(sorter.BasePath))
            {
                throw new Exception($"The base folder '{sorter.BasePath}' does not exist.");
            }
        }
    }
}