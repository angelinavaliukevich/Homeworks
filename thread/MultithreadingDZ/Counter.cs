using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDZ
{
    internal class Counter
    {
        private readonly int[] array;
        private long  totalCount;

        public  Counter(int [] array)
        {
            this.array = array;
        }
        private void InternalCalculaate(object obj)
        {
            int[] partOfArray = obj as int [];
            foreach (var item in partOfArray)
            {
                Interlocked.Add(ref totalCount, item);
            }
        }
        public long  Calculate()
        {
            Thread[] threads = new Thread[10];
            for ( int i =0; i< 10; i++)
            {
               int[] partArray = array.Skip(i*100_000).Take(100_000).ToArray();
                threads[i] = new Thread(InternalCalculaate);
                threads[i].Start(partArray);
                
            }
             foreach (var item in threads)
            {
                item.Join();
            }
            return totalCount;
        }
    }
}
