using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000); // Simulate a delay
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class Kiosk
{
    private static async Task ShowMenuAsync()
    {
        var backgroundOperation = new BackgroundOperation();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Kiosk - File Writer");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("Enter your choice (or 'q' to quit):");

            string choice = Console.ReadLine();

            if (choice == "q" || choice == "Q")
                break;

            string message = choice switch
            {
                "1" => "Hello World",
                "2" => DateTime.Now.ToString(),
                "3" => Environment.OSVersion.VersionString,
                _ => null
            };

            if (message != null)
            {
                Console.WriteLine("Writing to file...");
                await backgroundOperation.WriteToFileAsync(message);
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }

    public static async Task Main(string[] args)
    {
        await ShowMenuAsync();
    }
}
