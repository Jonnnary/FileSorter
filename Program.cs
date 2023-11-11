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
                // Display a message if the required argument is missing
                Console.WriteLine("You have to insert a path! ");
            }
        }
    }
}