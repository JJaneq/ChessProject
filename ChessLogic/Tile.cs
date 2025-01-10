namespace Chess.ChessLogic;

public class Tile
{
    public Piece? Piece { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public Tile(int row, int column)
    {
        Row = row;
        Column = column;
        Piece = null;
    }

    public Tile(int row, int column, Piece piece)
    {
        Row = row;
        Column = column;
        Piece = piece;
    }

    public override string ToString()
    {
        return (char)('A' + Column) + (8 - Row).ToString();
    }
}