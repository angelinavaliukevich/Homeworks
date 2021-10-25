using System;
using System.Diagnostics;
using System.Linq;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Stopwatch sw = Stopwatch.StartNew();

            int[] array = Enumerable.Range(1, 1000_000).ToArray();
            long count = 0;
            foreach (var item in array)
            {
                count += item;
            }
            Console.WriteLine("1)"+count);

            Counter.CalculateOut(array);
            Console.ReadKey();
            Console.WriteLine($"Время загрузки: {sw.Elapsed}");
           
        }
    }
}
