using System;
using System.IO;

// Step 1: Define the file paths
string filepath = "sample.txt";
string copyPath = "copy.txt";

try
{
    Console.WriteLine("Creating a file...");
    File.Create(filepath).Close();

    Console.WriteLine("Writing to a file...");
    File.WriteAllText(filepath, "Hello, this is the first line of the file..!!");

    Console.WriteLine("Appending data to the file...");
    File.AppendAllText(filepath, "\nThis data is appended to the text");

    Console.WriteLine("Reading from the file...");
    string content = File.ReadAllText(filepath);
    Console.WriteLine(content);
}
catch (Exception ex)
{
    Console.WriteLine("Error occurred: " + ex.Message);
}