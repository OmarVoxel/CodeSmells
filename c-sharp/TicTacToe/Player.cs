namespace TicTacToe;

public class Player
{
    public char Symbol { get; }
    public int CoordinateX { get; }
    public int CoordinateY { get; }
    public Player(char symbol, int coordinateX, int coordinateY)
    {
        Symbol = symbol;
        CoordinateX = coordinateX;
        CoordinateY = coordinateY;
    }
}