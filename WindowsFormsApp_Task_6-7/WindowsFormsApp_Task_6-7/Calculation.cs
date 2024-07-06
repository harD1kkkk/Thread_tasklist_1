using System;
using System.Collections.Generic;
using System.Threading;

namespace WindowsFormsApp_Task_6_7
{
    class Calculation
    {
        private readonly List<int> randomNum = new List<int>();
        private int num = 0;
        private int maxNum = 0;
        private int minNum = Int32.MaxValue;
        private double averageNum = 0;

        public void Clear()
        {
            num = 0;
            maxNum = 0;
            minNum = Int32.MaxValue;
            averageNum = 0;

        }

        public List<int> generateNums(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                num = random.Next(1, 10000);
                randomNum.Add(num);
            }
            return randomNum;
        }

        public int maxNumber()
        {
            Thread thread = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    if (maxNum < item)
                    {
                        maxNum = item;
                    }
                }

            });
            thread.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread.Join();
            }
            return maxNum;
        }

        public int minNumber()
        {
            Thread thread1 = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    if (minNum > item)
                    {
                        minNum = item;
                    }
                }
            });
            thread1.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread1.Join();
            }
            return minNum;
        }

        public double averageNumber()
        {
            Thread thread2 = new Thread(() =>
            {
                foreach (int item in randomNum)
                {
                    averageNum += item;
                }
                averageNum /= randomNum.Count;
            });
            thread2.Start();
            for (int i = 0; i <= randomNum.Count; i++)
            {
                thread2.Join();
            }
            return averageNum;
        }

    }
}
