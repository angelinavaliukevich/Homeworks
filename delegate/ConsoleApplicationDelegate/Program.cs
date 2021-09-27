using System;

namespace ConsoleApplicationDelegate
{
    class Program
    {
        public delegate int Delegate();
        public delegate double DeleMassiv(Delegate[] my);

        static void Main(string[] args)
        {
            Random rand = new Random();
            Delegate[] delegs = new Delegate[5];
            int sum = 0;
            int a = 0;
            DeleMassiv massivDelegate = (delegs) =>
            {
                for (int i = 0; i < delegs.Length; i++)
                {
                    delegs[i] = () => { a = rand.Next(100); sum += a; Console.WriteLine(a); return sum; };
                    delegs[i]();
                }
                return (double)sum / delegs.Length;
            };
            Console.WriteLine("Cреднее арифметическое: " + massivDelegate(delegs));
            {




            }
        }
    }
}

