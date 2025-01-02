namespace Chess.ChessLogic;

public class Pawn : Piece
{
    public Pawn(char color, int row, int col) : base(color, row, col)
    {
        //PieceType = PieceType.Pawn;
        PieceType = 'p';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        List<Tile> possibleMoves = new List<Tile>();
        int direction = Color == 'w' ? -1 : 1; // Kierunek ruchu zależny od koloru

        // Ruch do przodu
        Tile forwardTile = board.GetTile(Row + direction, Col);
        if (forwardTile != null && forwardTile.Piece == null)
        {
            possibleMoves.Add(forwardTile);

            // Podwójny ruch, jeśli pionek się jeszcze nie poruszał
            if (!Moved)
            {
                Tile doubleForwardTile = board.GetTile(Row + 2 * direction, Col);
                if (doubleForwardTile != null && doubleForwardTile.Piece == null)
                {
                    possibleMoves.Add(doubleForwardTile);
                }
            }
        }
        return possibleMoves;
    }
}