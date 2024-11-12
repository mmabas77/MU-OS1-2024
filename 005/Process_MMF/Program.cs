using System.Diagnostics;

namespace Process_MMF;

public class Program
{
    public static void Main(string[] args)
    {
        StartChrome();
        RestartIfLessThan();
    }

    private static void RestartIfLessThan(int maxInstances = 30)
    {
        // Check if the current process has two or fewer instances running
        int count = Process.GetProcessesByName(
            Process.GetCurrentProcess().ProcessName
        ).Count();
        Console.WriteLine("Iam process number : {0}", count);
        if (count < maxInstances)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "Process_MMF.exe",
                UseShellExecute = true, // This will open it in a new window
            };
            Process.Start(startInfo);
        }
        // Console.ReadKey();
    }

    public static void StartChrome()
    {
        // Set up the start info to open Chrome with the specified URL
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "chrome.exe", // Path to Chrome executable
            Arguments = "google.com", // The URL to open
            UseShellExecute = true // Opens Chrome in a new window
        };
        
        Process.Start(startInfo);
    }
}