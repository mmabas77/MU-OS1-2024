using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static long totalSum = 0; // Shared variable to hold the total sum
    static object lockObject = new object(); // Lock object to prevent race conditions

    static void Main()
    {
        Console.WriteLine("Single-threaded process started.");

        // Start timing
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Perform the task Sum one billion numbers.
        CalculatePartialSum(1, 1_000_000_000);

        // Stop timing
        stopwatch.Stop();

        Console.WriteLine($"Single-threaded sum: {totalSum}");
        Console.WriteLine($"Time taken (single-threaded): {stopwatch.ElapsedMilliseconds} ms");


        // -----------------------------------------------------
         Console.WriteLine("Multi-threaded process started.");
         totalSum = 0;
        
        // Start timing
        stopwatch.Reset();
        stopwatch.Start();
        
        // Define ranges for each thread
        Thread thread1 = new Thread(() => CalculatePartialSum(1, 250_000_000));
        Thread thread2 = new Thread(() => CalculatePartialSum(250_000_001, 500_000_000));
        Thread thread3 = new Thread(() => CalculatePartialSum(500_000_001, 750_000_000));
        Thread thread4 = new Thread(() => CalculatePartialSum(750_000_001, 1_000_000_000));
        
        // // Start all threads
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        //
        // // Wait for all threads to complete
        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
        //
        // Stop timing
        stopwatch.Stop();
        //
        Console.WriteLine($"Multi-threaded sum: {totalSum}");
        Console.WriteLine($"Time taken (multi-threaded): {stopwatch.ElapsedMilliseconds} ms");
    }

    // Method to calculate partial sum within a range
    static void CalculatePartialSum(int start, int end)
    {
        // ----- ----- With & Without lock (Partial SUM) ----- ----- //
        long partialSum = 0;
        for (int i = start; i <= end; i++)
        {
            partialSum += i;
        }
        
        lock (lockObject)
        {
         totalSum += partialSum;
        }

        // ----- ----- Without lock (Total SUM) ----- ----- //
        // for (int i = start; i <= end; i++)
        // {
        //     totalSum += i;
        // }

        // ----- ----- With lock (Total SUM) ----- ----- //
        // for (int i = start; i <= end; i++)
        // {
        //     lock (lockObject)
        //     {
        //         totalSum += i;
        //     }
        // }
    }
}