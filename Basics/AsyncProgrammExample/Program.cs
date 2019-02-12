using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"test.Data";
            file = GetFilePath(file); 
            Console.WriteLine(Directory.GetCurrentDirectory());
            if (!File.Exists(file) )
                Console.WriteLine($"File {file} with test data in project root folder does not exist");;

            Console.WriteLine("Please wait patiently " +
                              "while I do something important.");

            Task<int> task = HandleFileAsync(file);

            // Do something at the same time as the file is being read.
            string line = Console.ReadLine();
            Console.WriteLine("You entered (asynchronous logic): " + line);


            // Wait for the HandleFile task to complete.
            // ... Display its results.
            task.Wait();
            var x = task.Result;
            Console.WriteLine("Count: " + x);

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

            return;
            //var filepath = @"D:\programs\enable1.txt";
                    }



        static string GetFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + fileName;
        }

        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine($"Number of lines in file: {count} ");
            Console.WriteLine("HandleFile exit");
            return count;
        }
    }
}
