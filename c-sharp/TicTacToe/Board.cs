using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private List<Tile> _plays = new();

        public Board()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int matrixM = 0; matrixM < 3; matrixM++)
            {
                for (int matrixN = 0; matrixN < 3; matrixN++)
                {
                    _plays.Add(new Tile
                    {
                        CoordinateX = matrixM,
                        CoordinateY = matrixN,
                        Symbol = ' '
                    });
                }
            }
        }

        public Tile TileAt(int coordinateX, int coordinateY) 
            => _plays.Single(tile => tile.CoordinateX == coordinateX && tile.CoordinateY == coordinateY);

        public void AddTileAt(Player player) 
            => _plays.Single(tile => tile.CoordinateX == player.CoordinateX && tile.CoordinateY == player.CoordinateY).Symbol = player.Symbol;

        public char GetWinner()
        {
            if (FirstRowHasAWinner())
                return TileAt(0, 0).Symbol;

            if (SecondRowHasAWinner())
                return TileAt(1, 0).Symbol;

            return ThirdRowHasAWinner() ? TileAt(2, 0).Symbol : ' ';
        }

        private bool FirstRowHasAWinner()
        {
            if (TileAt(0, 0).Symbol != ' ' &&
                TileAt(0, 1).Symbol != ' ' &&
                TileAt(0, 2).Symbol != ' ')
            {
                return TileAt(0, 0).Symbol ==
                       TileAt(0, 1).Symbol &&
                       TileAt(0, 2).Symbol ==
                       TileAt(0, 1).Symbol;
            }

            return false;
        }

        private bool SecondRowHasAWinner()
        {
            if (TileAt(1, 0).Symbol != ' ' &&
                TileAt(1, 1).Symbol != ' ' &&
                TileAt(1, 2).Symbol != ' ')
            {
                return TileAt(1, 0).Symbol ==
                       TileAt(1, 1).Symbol &&
                       TileAt(1, 2).Symbol ==
                       TileAt(1, 1).Symbol;
            }

            return false;
        }

        private bool ThirdRowHasAWinner()
        {
            if (TileAt(2, 0).Symbol != ' ' &&
                TileAt(2, 1).Symbol != ' ' &&
                TileAt(2, 2).Symbol != ' ')
            {
                return TileAt(2, 0).Symbol ==
                       TileAt(2, 1).Symbol &&
                       TileAt(2, 2).Symbol ==
                       TileAt(2, 1).Symbol;
            }

            return false;
        }
    }
}