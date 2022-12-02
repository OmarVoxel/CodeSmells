using System;

namespace TicTacToe
{
    public class Game
    {
        private char _lastSymbol = ' ';
        private readonly Board _board = new();
        
        public void Play(char symbol, int coordinateX, int coordinateY)
        {
            CheckRules(symbol, coordinateX, coordinateY);
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, coordinateX, coordinateY);
        }
        
        private void CheckRules(char symbol, int coordinateX, int coordinateY)
        {
            if(IsAnInvalidFirstMove(symbol))
              throw new Exception("Invalid first player");

            if(PlayerRepeat(symbol))
                throw new Exception("Invalid next player");
            
            if(TileIsNotEmpty(coordinateX, coordinateY))
                throw new Exception("Invalid position");
        }

        private bool TileIsNotEmpty(int coordinateX, int coordinateY)
            => _board.TileAt(coordinateX, coordinateY).Symbol != ' ';
        
        private bool IsAnInvalidFirstMove(char symbol) 
            => _lastSymbol == ' ' && symbol == 'O';
        
        private bool PlayerRepeat(char symbol)
            => symbol == _lastSymbol;
        
        public char Winner()
            => _board.GetWinner();
        
        private char GetSymbol(int coordinateX, int coordinateY)
            => _board.TileAt(coordinateX, coordinateY).Symbol;
    }
}