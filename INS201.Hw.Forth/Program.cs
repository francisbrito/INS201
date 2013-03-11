using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INS201.Structures;

namespace INS201.Hw.Forth
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dictonary<string, int>();

            Console.WriteLine(d.Length);
            d.Insert("Hello", 1);
            d.Insert("World", 2);
            d.Remove("Hello");
            Console.WriteLine(d.Find("World"));

            for (int i = 1; i <= 1000000; i++)
            {
                var key = string.Format("{0}", i);

                d.Insert(key, i);
            }

            Console.WriteLine(d.Find("1"));
            Console.WriteLine(d.Find("256"));
            Console.WriteLine(d.Find("1013"));
            Console.WriteLine(d.Find("9999"));
            Console.WriteLine(d.Find("199881"));
            Console.WriteLine(d.Find("1000000"));

        }
    }
}
