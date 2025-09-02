using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Task 1: File Handling
        string filePath = "favorites.txt";

        Console.WriteLine("Enter your 5 favorite colors:");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Color {i}: ");
                string color = Console.ReadLine();
                writer.WriteLine(color);
            }
        }

        Console.WriteLine("\nYour favorite colors are:");
        string[] colors = File.ReadAllLines(filePath);
        foreach (var color in colors)
        {
            Console.WriteLine(color);
        }

        // Task 2: Asynchronous Programming
        Console.WriteLine("\nStarting file download...");
        await DownloadFileAsync();
    }

    // Async method to simulate file download
    static async Task DownloadFileAsync()
    {
        await Task.Delay(5000); // wait 5 seconds
        Console.WriteLine("Download complete!");
    }
}
