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
            var number = 1000000;
            var d = new Dictionary<string, int>();

            Console.WriteLine(d.Length);
            d.Insert("Hello", 1);
            d.Insert("World", 2);
            d.Remove("Hello");
            Console.WriteLine(d.Find("World"));

            for (int i = 1; i <= number; i++)
            {
                var key = string.Format("{0}", i);

                d.Insert(key, i);
            }

            // d.Remove("1");

            Console.WriteLine(d.Find("1"));
            Console.WriteLine(d.Find("2"));
            Console.WriteLine(d.Find("4"));
            Console.WriteLine(d.Find("8"));
            Console.WriteLine(d.Find("999999"));

            //var dd = new Dictionary<string, int>();

            //for (int i = 1; i <= number; i++)
            //{
            //    var key = string.Format("{0}", i);

            //    dd.Add(key, i);
            //}

            //Console.WriteLine(dd["999999"]);
        }
    }
}
