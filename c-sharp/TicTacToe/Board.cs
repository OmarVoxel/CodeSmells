using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile {CoordinateX = i, CoordinateY = j, Symbol = ' '});
                }
            }
        }

        public Tile TileAt(int coordinateX, int coordinateY)
        {
            return _plays.Single(tile => tile.CoordinateX == coordinateX && tile.CoordinateY == coordinateY);
        }

        public void AddTileAt(char symbol, int x, int y)
        {
            _plays.Single(tile => tile.CoordinateX == x && tile.CoordinateY == y).Symbol = symbol;
        }
    }
}