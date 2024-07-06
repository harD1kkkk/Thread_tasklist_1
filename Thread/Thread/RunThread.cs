using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace MyThread
{
    public class RunThread
    {
        public void Task1()
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(i);

                }
            });
            thread.Start();
            for (int i = 0; i < 50; i++)
            {
                thread.Join();
            }
        }
        public void Task2()
        {
            Console.Write("Input start of numbers: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Input end of numbers: ");
            int end = Int32.Parse(Console.ReadLine());

            Thread thread = new Thread(() =>
            {
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine(i);

                }
            });
            thread.Start();
            for (int i = start; i <= end; i++)
            {
                thread.Join();
            }
        }

        public void Task3()
        {
            Console.Write("Input start of numbers: ");
            int start = Int32.Parse(Console.ReadLine());

            Console.Write("Input end of numbers: ");
            int end = Int32.Parse(Console.ReadLine());

            Console.Write("Input number of threads: ");
            int number = Int32.Parse(Console.ReadLine());

            Thread[] threads = new Thread[number];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() => Run(start, end));
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }
        static void Run(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void Task4()
        {
            Console.Write("Input how many numbers generate: ");
            int count = Int32.Parse(Console.ReadLine());

            Random random = new Random();

            List<int> randomNum = new List<int>();

            int num = 0;
            int maxNum = 0;
            int minNum = Int32.MaxValue;
            double averageNum = 0;

            for (int i = 0; i < count; i++)
            {
                num = random.Next(1, 10000);
                randomNum.Add(num);
            }
            foreach (int item in randomNum)
            {
                Console.WriteLine(item);
            }

            Thread thread = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    if (maxNum < item)
                    {
                        maxNum = item;
                    }
                }
                Console.WriteLine("Max number: " + maxNum);
            });
            thread.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread.Join();
            }
            Thread thread1 = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    if (minNum > item)
                    {
                        minNum = item;
                    }
                }
                Console.WriteLine("Min number: " + minNum);
            });
            thread1.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread1.Join();
            }
            Thread thread2 = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    averageNum += item;
                }
                averageNum /= randomNum.Count;

                Console.WriteLine("Average number: " + averageNum);
            });
            thread2.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread2.Join();
            }
            Task5(maxNum, minNum, averageNum);
        }

        public void Task5(int maxNum, int minNum, double averageNum)
        {
            string fileName = "Results";
            string filePath = $"..\\..\\{fileName}.json";

            var results = new Dictionary<string, object>
            {
                { "MaxNumber", maxNum },
                { "MinNumber", minNum },
                { "AverageNumber", averageNum }
            };

            string json = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);

            Console.WriteLine($"Results saved to {filePath}");
        }
    }
}
