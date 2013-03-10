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
            //var d = new Dictonary<string, int>();

            //Console.WriteLine(d.Length);
            //d.Insert("Hello", 1);
            //d.Insert("World", 2);
            //d.Remove("Hello");
            //Console.WriteLine(d.Find("World"));

            Dictionary<string, int> dd = new Dictionary<string, int>();

            for (int i = 0; i < 1000000; i++)
            {
                dd.Add(string.Format("{0}", i), i);
            }

            foreach (var item in dd)
            {
                Console.WriteLine("K: {0}\tH(K): {1}\tV: {2}\tH(V): {3}", item.Key, item.Key.GetHashCode(),
                    item.Value, item.Value.GetHashCode());
            }
        }
    }
}
