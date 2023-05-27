using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GottaHaveStandards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, hope you're having a wonderful day!");
            Console.WriteLine("Now, go away.");
            Console.WriteLine(":P\r\n\r\n");


            ProcessFactory tester = new ProcessFactory();
            var results = tester.Duration()
                                .Retry()
                                .FailMe()
                                .execute(() => {
                Console.WriteLine("--- running ---\r\n\r\n");
                Task.Delay(500).Wait();
            });

            Console.WriteLine("\r\n\r\n---- Result: ");
            Console.WriteLine("... hadError: {0}", results.hadError);
            Console.WriteLine("... duration: {0}", results.DurationResult().TotalMilliseconds );
            Console.WriteLine("... retry successful: {0}", results.RetryResult().successful);


            //Console.WriteLine("\r\n\r\nPress Any Key To Quit...");
            //Console.ReadKey();
        }
    }
}
