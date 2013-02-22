using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Hw.First
{
    public class GeneralizedTicTacToe
    {
        private int _rows, _columns, _sequenceLength;
        private char _whoseTurn;
        private char[,] _grid;
        private char _winner;
        private bool _foundWinner;

        public const char DEFAULT_CHAR = '\0';

        public GeneralizedTicTacToe(int rows, int columns, int sequenceLength)
        {
            _rows = rows;
            _columns = columns;
            _sequenceLength = sequenceLength;

            _grid = new char[rows, columns];

            _winner = '?';
        }

        public GeneralizedTicTacToe()
            : this(3, 3, 3)
        {

        }

        #region Extra Properties
        // This properties were not required by the assignment, 
        // nevertheless, its nice having them around for testing and stuff.
        public int Rows
        {
            get
            {
                return _rows;
            }
        }

        public int Columns
        {
            get
            {
                return _columns;
            }
        }

        public int SequenceLength
        {
            get
            {
                return _sequenceLength;
            }
        }

        public char[,] Grid
        {
            get
            {
                return _grid;
            }
        }

        #endregion

        public char WhoseTurn()
        {
            // If it was X's turn...
            if (_whoseTurn == 'X')
            {
                _whoseTurn = 'O'; // Now it's O's turn.
            }
            // Otherwise...
            else
            {
                _whoseTurn = 'X'; // It's X's turn.
            }

            return _whoseTurn;
        }

        // Do "Run-Around" then linear search.
        public void Play(int row, int column)
        {
            // If bound is invalid...
            if (row < 0 || row > _rows || column < 0 || column > _columns)
            {
                throw new IndexOutOfRangeException();
            }
            // If cell is occupied...
            else if (_grid[row, column] != DEFAULT_CHAR)
            {
                throw new InvalidOperationException("Cell already marked.");
            }
            // If game is over (i.e: a winner was found)...
            else if (_winner != '?')
            {
                var msg = string.Format("Game is over. Winner was {0}", _winner);
                throw new InvalidOperationException(msg);
            }

            _grid[row, column] = WhoseTurn();

        }

        public void Print()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (_grid[i, j] == DEFAULT_CHAR)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write("{0}", _grid[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }

        public char Winner
        {
            get
            {
                return _foundWinner ? _winner : FindWinner();
            }
        }

        private char FindWinner()
        {
            char ret = '?';

            int XsToWin = _sequenceLength;

            for (int i = 0; i < _columns; i++)
            {
                char pivot = _grid[0, i];

                if (pivot == 'X')
                {
                    XsToWin--;
                }

                if (XsToWin == 0)
                {
                    _foundWinner = true;
                    _winner = ret = 'X';
                    break;
                }
            }

            return ret;
        }
    }
}
