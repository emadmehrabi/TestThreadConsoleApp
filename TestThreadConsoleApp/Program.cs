using System;
using System.IO;
using System.Threading;

namespace TestThreadConsoleApp
{
    static class Program
    {
        private static string Path1 { get; } = @"c:\temp\MyTest1.txt";

        private static void Main()
        {
            if (!File.Exists(Path1))
            {
                using (StreamWriter sw = File.CreateText(Path1))
                {
                    sw.WriteLine("Hello And Welcome");
                }
            }
            Console.WriteLine("Running...");

            var t1 = new Thread(Write1);
            t1.Start();

            var t2 = new Thread(Write2);
            t2.Start();

            Console.ReadLine();
        }        
        private static void Write1()
        {
            try
            {
                while (true)
                {
                    using (StreamWriter sw = File.AppendText(Path1))
                    {
                        sw.WriteLine("write1 " + DateTime.Now);
                    }

                    Thread.Sleep(100);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static void Write2()
        {
            try
            {
                while (true)
                {
                    using (StreamWriter sw = File.AppendText(Path1))
                    {
                        sw.WriteLine("write2 " + DateTime.Now);
                    }

                    Thread.Sleep(500);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
