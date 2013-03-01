using INS201.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Hw.Third
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Deque<int>();

            d.AddBack(4);
            d.AddBack(12);
            d.AddFront(7);
            d.AddBack(-6);
            d.AddFront(0);

            Console.WriteLine(d.Length);
            Console.WriteLine(d.Back());
            Console.WriteLine(d.PopFront());
            Console.WriteLine(d.At(2));
        }
    }
}
