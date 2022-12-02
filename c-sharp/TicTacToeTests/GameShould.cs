using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTests
{
    public class GameShould
    {
        private Game game;

        public GameShould()
        {
           game = new Game();
        }

        [Fact]
        public void NotAllowPlayerOToPlayFirst()
        {
            Action wrongPlay = () => game.Play(new Player('O', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid first player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play(new Player('X', 0, 0));
            
            Action wrongPlay = () => game.Play(new Player('X', 1, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid next player", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play(new Player('X', 0, 0));

            Action wrongPlay = () => game.Play(new Player('O', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play(new Player('X', 0, 0));
            game.Play(new Player('O', 1, 0));

            Action wrongPlay = () => game.Play(new Player('X', 0, 0));

            var exception = Assert.Throws<Exception>(wrongPlay);
            Assert.Equal("Invalid position", exception.Message);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play(new Player('X', 0, 0));
            game.Play(new Player('O', 1, 0));
            game.Play(new Player('X', 0, 1));
            game.Play(new Player('O', 1, 1));
            game.Play(new Player('X', 0, 2));

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play(new Player('X', 2, 2));
            game.Play(new Player('O', 0, 0));
            game.Play(new Player('X', 1, 0));
            game.Play(new Player('O', 0, 1));
            game.Play(new Player('X', 1, 1));
            game.Play(new Player('O', 0, 2));

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(new Player('X', 1, 0));
            game.Play(new Player('O', 0, 0));
            game.Play(new Player('X', 1, 1));
            game.Play(new Player('O', 0, 1));
            game.Play(new Player('X', 1, 2));

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play(new Player('X', 0, 0));
            game.Play(new Player('O', 1, 0));
            game.Play(new Player('X', 2, 0));
            game.Play(new Player('O', 1, 1));
            game.Play(new Player('X', 2, 1));
            game.Play(new Player('O', 1, 2));

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }

        [Fact]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play(new Player('X', 2, 0));
            game.Play(new Player('O', 0, 0));
            game.Play(new Player('X', 2, 1));
            game.Play(new Player('O', 0, 1));
            game.Play(new Player('X', 2, 2));

            var winner = game.Winner();

            Assert.Equal('X', winner);
        }

        [Fact]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play(new Player('X', 0, 0));
            game.Play(new Player('O', 2, 0));
            game.Play(new Player('X', 1, 0));
            game.Play(new Player('O', 2, 1));
            game.Play(new Player('X', 1, 1));
            game.Play(new Player('O', 2, 2));

            var winner = game.Winner();

            Assert.Equal('O', winner);
        }
    }
}
