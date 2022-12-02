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
                    _plays.Add(new Tile {CoordenateX = i, CoordenateY = j, Symbol = ' '});
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            return _plays.Single(tile => tile.CoordenateX == x && tile.CoordenateY == y);
        }

        public void AddTileAt(char symbol, int x, int y)
        {
            var newTile = new Tile
            {
                CoordenateX = x,
                CoordenateY = y,
                Symbol = symbol
            };

            _plays.Single(tile => tile.CoordenateX == x && tile.CoordenateY == y).Symbol = symbol;
        }
    }
}