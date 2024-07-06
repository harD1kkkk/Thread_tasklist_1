using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunThread runThreadpool = new RunThread();

            runThreadpool.Task1();
            runThreadpool.Task2();
            runThreadpool.Task3();
            runThreadpool.Task4();

            Console.WriteLine("End of writing");
            Console.ReadLine();
        }
    }
}
