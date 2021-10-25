using System;
using System.Linq;
using System.Threading;

namespace MultithreadingDZ
{
    class Program
    {
        static void Main(string[] args)
        {

            //    Timer timer = new Timer(() => Console.WriteLine("///"), 2);

            //    timer.Start();
            //    Thread.Sleep(5000);
            //    timer.Stop();
            int[] array = Enumerable.Range(1, 1000_000).ToArray();
            long count  = 0;
            foreach (var item in array)
            {
                count += item;
             }
            Console.WriteLine(count);
            Counter counter = new Counter(array);
            Console.WriteLine(counter.Calculate());
            Console.ReadKey();
        }
    }
}
