using System;
using System.Threading;

class Program
{
    // Shared variable to demonstrate race condition
    static int counter = 0;
    static object lockObject = new object(); // Lock object to prevent race conditions


    static void Main()
    {
        Console.WriteLine("Starting Thread Pool Example with Increment and Decrement Tasks");

        // ThreadPool example - queue multiple tasks to increment and decrement counter
        ThreadPool.SetMaxThreads(1,50);
        ThreadPool.QueueUserWorkItem(IncrementCounter);
        ThreadPool.QueueUserWorkItem(DecrementCounter);
        ThreadPool.QueueUserWorkItem(IncrementCounter);
        ThreadPool.QueueUserWorkItem(DecrementCounter);

        // Wait for a moment to see race condition effect
        Thread.Sleep(500); // Note: this is for demo purposes, not ideal in real applications

        Console.WriteLine($"Final counter value after Thread Pool (may vary due to race condition): {counter}");
    }

    // Method to increment the counter in ThreadPool
    static void IncrementCounter(object state)
    {
        // Lock the shared variable to prevent race conditions
        // lock (lockObject)
        //     {
        // Simulate a critical section where race condition can happen
        for (int i = 0; i < 1000000; i++) // Increased iterations to 1000
        {
            // Simulate a critical section where race condition can happen
            counter++;
        }

        Thread.Sleep(1); // Small delay to increase race condition chance
        // }
    }

    // Method to decrement the counter in ThreadPool
    static void DecrementCounter(object state)
    {
        // Lock the shared variable to prevent race conditions
        // lock (lockObject)
        //     {
        // Simulate a critical section where race condition can happen
        for (int i = 0; i < 1000000; i++) // Increased iterations to 1000
        {
            // Simulate a critical section where race condition can happen
            counter--;
        }

        Thread.Sleep(1); // Small delay to increase race condition chance
        // }
    }
}