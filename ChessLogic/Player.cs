namespace Chess.ChessLogic;

public class Player
{
    public char Color { get; set; }

    //public List<Piece> Pieces { get; set; }

    public Player(char color)
    {
        Color = color;
    }
}