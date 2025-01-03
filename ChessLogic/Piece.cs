namespace Chess.ChessLogic;

public abstract class Piece
{
    public char Color {get; set;}
    public char PieceType {get; set;}
    public Boolean Moved {get; set;}
    public int Row {get; set;}
    public int Col {get; set;}

    public Piece(char color, int row, int col)
    {
        Color = color;
        Moved = false;
        Row = row;
        Col = col;
    }

    public abstract List<Tile> GetPossibleMoves(Board board);

    public abstract List<Tile> GetGuardedTiles(Board board);
}