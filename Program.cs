// This program is a simple file sorter that organizes files in a specified directory
// based on their file extensions. It uses a predefined list of allowed file extensions.

// Import necessary namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    // Main program class
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check if a command-line argument (directory path) is provided
            if (args.Length == 1)
            {
                // Create a Sorter instance and initiate the sorting process
                Sorter sorter = new Sorter();
                sorter.BasePath = args[0];
                sorter.Start();
            }
            else
            {
                // If no command-line argument is provided, prompt the user for the directory path
                Console.WriteLine("Enter the path you want to sort: ");

                // Read user input for the directory path
                string userin = Console.ReadLine();

                // Create a Sorter instance with the user-provided directory path and initiate the sorting process
                Sorter sorter = new Sorter();
                sorter.BasePath = userin;
                sorter.Start();
            }
        }
    }
}