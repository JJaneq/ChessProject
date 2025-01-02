namespace Chess.ChessLogic;

public class Queen : Piece
{
    public Queen(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'q';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        return null;
    }
}