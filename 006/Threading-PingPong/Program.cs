using System.Diagnostics;

namespace Threading;

public class Program
{
    public static void Main()
    {
        Stopwatch stopwatch = new  Stopwatch();
        stopwatch.Start();
        
        // Do the job here ..
        PingPong();
        
        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }

    private static void PingPong()
    {
         // Without threading
         // Ping();
         // Pong();
        
         Console.WriteLine("--------------------");
        
         // With threading
         Thread pingThread = new Thread(Ping);
         Thread pongThread = new Thread(Pong);
        
         // Background vs Foreground threads
         // pingThread.IsBackground = true;
         // pongThread.IsBackground = true;
        
         // Start the threads
         pingThread.Start();
         pongThread.Start();
        
         // Not supported anymore .. why ?
         // pingThread.Abort();
         //
         // Console.WriteLine("--------------------");
         //
         pingThread.Join();
         // pongThread.Join();
        
         // Will cause error .. why ?
        pingThread.Start();
        
         Console.WriteLine("--------------------");
         // Console.WriteLine("Join finished");
    }

    private static void MainThreadName()
    {
        // Get the current thread
        Thread currentThread = Thread.CurrentThread;
        
        // Get the current thread's name
        string currentThreadName = currentThread.Name ?? "No name";
        Console.WriteLine($"Current thread name: {currentThreadName}");
        
        // Set the current thread's name
        currentThread.Name = "Main Thread";
        Console.WriteLine($"Current thread name: {currentThread.Name}");
    }
    
    // Loop to be excuted by the thread
    private static void Ping()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Ping: {i}");
        }
    }
    
    private static void Pong()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Pong: {i}");
            Thread.Sleep(1000);
        }
    }
    
}