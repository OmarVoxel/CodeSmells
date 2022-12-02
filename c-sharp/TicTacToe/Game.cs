using System;

namespace TicTacToe
{
    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
        
        public void Play(char symbol, int coordinateX, int coordinateY)
        {
            CheckRules(symbol, coordinateX, coordinateY);

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, coordinateX, coordinateY);
        }
        
        private void CheckRules(char symbol, int coordinateX, int coordinateY)
        {
            if(IsAnInvalidFirstMove(symbol))
              throw new Exception("Invalid first player");

            if(PlayerRepeat(symbol))
                throw new Exception("Invalid next player");
            
            if(TileIsNotEmpty(symbol, coordinateX, coordinateY))
                throw new Exception("Invalid position");
        }

        private bool TileIsNotEmpty(char symbol, int coordinateX, int coordinateY)
            => _board.TileAt(coordinateX, coordinateY).Symbol != ' ';
        
        private bool IsAnInvalidFirstMove(char symbol) 
            => _lastSymbol == ' ' && symbol == 'O';
        
        private bool PlayerRepeat(char symbol)
            => symbol == _lastSymbol;
        
        public char Winner()
        {   //if the positions in first row are taken
            if(_board.TileAt(0, 0).Symbol != ' ' &&
               _board.TileAt(0, 1).Symbol != ' ' &&
               _board.TileAt(0, 2).Symbol != ' ')
               {
                    //if first row is full with same symbol
                    if (_board.TileAt(0, 0).Symbol == 
                        _board.TileAt(0, 1).Symbol &&
                        _board.TileAt(0, 2).Symbol == 
                        _board.TileAt(0, 1).Symbol )
                        {
                            return _board.TileAt(0, 0).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(_board.TileAt(1, 0).Symbol != ' ' &&
                _board.TileAt(1, 1).Symbol != ' ' &&
                _board.TileAt(1, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(1, 0).Symbol == 
                        _board.TileAt(1, 1).Symbol &&
                        _board.TileAt(1, 2).Symbol == 
                        _board.TileAt(1, 1).Symbol)
                        {
                            return _board.TileAt(1, 0).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(_board.TileAt(2, 0).Symbol != ' ' &&
                _board.TileAt(2, 1).Symbol != ' ' &&
                _board.TileAt(2, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(2, 0).Symbol == 
                        _board.TileAt(2, 1).Symbol &&
                        _board.TileAt(2, 2).Symbol == 
                        _board.TileAt(2, 1).Symbol)
                        {
                            return _board.TileAt(2, 0).Symbol;
                        }
                }

            return ' ';
        }
    }
}