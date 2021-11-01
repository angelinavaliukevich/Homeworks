using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            // асинхронного выполнения
            Console.WriteLine("Время асинхронного выполнения");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CalculateAsync();
            Console.ReadKey();
        }

        static async void CalculateAsync() {
            Stopwatch sw2 = Stopwatch.StartNew();
            CreditCalculator calculator2 = new CreditCalculator();
            CreditInfo info2 = await  CreditCalculator.Calculate();
            Console.WriteLine($"Время загрузки: {sw2.Elapsed}");
            Console.WriteLine(info2);
        }

    }
}
