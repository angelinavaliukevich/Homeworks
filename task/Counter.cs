using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Counter
    {
        private static readonly int[] array;
        private static long  totalCount;

        public  Counter(int [] array)
        {
           // this.array = array;
        }

        private static void InternalCalculaate(object obj)
        {
            int[] partOfArray = obj as int [];
            foreach (var item in partOfArray)
            {
                Interlocked.Add(ref totalCount, item);
            }
        }
        public static async Task Calculate(int[] array)
        {
            for ( int i =0; i< 10; i++)
            {
               int[] partArray = array.Skip(i*100_000).Take(100_000).ToArray();
               await Task.Run(() => InternalCalculaate(partArray));
                //threads[i] = new Thread(InternalCalculaate);
                //threads[i].Start(partArray);
            }
        }
        public static async void CalculateOut(int[] setarray) {
            //array = new setarray;
            await Calculate(setarray);
            Console.WriteLine(totalCount);
        }

    }
}
