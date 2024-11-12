using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Main thread started.");

        // Create a new thread, passing in the method it should execute
        Thread myThread = new Thread(PrintNumbers);

        // Start the thread
        myThread.Start();
        
        // Using Fork-Join style with threads
        // Wait for the new thread to complete
        myThread.Join();

        Console.WriteLine("Main thread completed.");
    }

    // Method to be executed in a separate thread
    static void PrintNumbers()
    {
        Console.WriteLine("Secondary thread started.");

        // Loop to print numbers from 1 to 5
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Number: {i}");
            Thread.Sleep(500); // Pause for 500ms to simulate work
        }

        Console.WriteLine("Secondary thread completed.");
    }
}
