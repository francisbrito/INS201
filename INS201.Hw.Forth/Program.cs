using System;
using System.Collections.Generic;
using System.Linq;
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
            d.Delete("Hello");
            Console.WriteLine(d.Find("World"));
        }
    }
}
