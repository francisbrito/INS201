using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Hw.First
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralizedTicTacToe game = new GeneralizedTicTacToe(3, 3, 3);
            
            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(1, 0);
            game.Play(1, 2);
            Console.WriteLine("Whose Turn: {0}", game.WhoseTurn());
            game.Play(2, 1);
            game.Play(0, 1);
            game.Play(2, 0);
            game.Play(0, 2);
            game.Play(2, 2);
            Console.WriteLine("Who Won: {0}", game.Winner);
            game.Print();

        }
    }
}
