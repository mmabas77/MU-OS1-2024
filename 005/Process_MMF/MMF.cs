using System.IO.MemoryMappedFiles;
using System.Text;

namespace Process_MMF;

public class MMF
{
    
    public static void M7ain(string[] args)
    {
        // Define the file path and size
        string filePath = "largefile.txt";
        long fileSize = 1024 * // = 1 KB
                        1024 * // = 1 MB
                        100; //   = 100 MB
    
        // Create or open the memory-mapped file
        using (
            var mmf = MemoryMappedFile.CreateFromFile(filePath, FileMode.OpenOrCreate, null, fileSize)
            )
        {
            // Create a memory-mapped view accessor to read and write data
            using (var accessor = mmf.CreateViewAccessor())
            {
                // Write data to the memory-mapped file
                string dataToWrite = "Hello, Memory-Mapped Files!";
                byte[] dataBytes = Encoding.UTF8.GetBytes(dataToWrite);
                accessor.WriteArray(30, dataBytes, 0, dataBytes.Length);
    
                // Read data from the memory-mapped file
                byte[] readData = new byte[2];
                accessor.ReadArray(34, readData, 0, 2);
    
                string readDataString = Encoding.UTF8.GetString(readData);
                Console.WriteLine("Data read from memory-mapped file: " + readDataString);

                Console.ReadKey();
            }
        }
    }
    
}