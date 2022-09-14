using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            int c = (int)counter;
        }
    }

    public class Counter
    {
        public int Second { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Second = x };
        }

        public static explicit operator int(Counter counter)
        {
            return counter.Second;
        }
    }
}
