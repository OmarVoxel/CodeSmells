﻿using System;

namespace TicTacToe
{
    public class Game
    {
        private char _lastSymbol = ' ';
        private readonly Board _board = new();
        
        public void Play(Player player)
        {
            CheckRules(player);
            _lastSymbol = player.Symbol;
            _board.AddTileAt(player);
        }
        
        private void CheckRules(Player player)
        {
            if(IsAnInvalidFirstMove(player.Symbol))
              throw new Exception("Invalid first player");

            if(PlayerRepeat(player.Symbol))
                throw new Exception("Invalid next player");
            
            if(TileIsNotEmpty(player.CoordinateX, player.CoordinateY))
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
    }
}