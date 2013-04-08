using INS201.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Hw.Fifth
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();

            for (int i = 1; i <= 20; i++)
            {
                tree.Insert(i, i * 10);
            }

            tree.Root.TraverseAndDo(tn => Console.WriteLine("{0}", tn.Value));
        }
    }
}
