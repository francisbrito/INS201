using System;
using System.IO;
//using System.Collections.Generic;
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
            var path = "@../../../../file/";

            var d = new Dictionary<string, int>();

            // Read common passwords from a file.
            var passwords = File.ReadAllLines(path + "passwords.txt");

            for (int i = 0; i < passwords.Length; i++)
            {
                d.Insert(passwords[i], new Random().Next()); // Values dont really matter.
            }
            
            d.PrintHistogram();
        }
    }
}
