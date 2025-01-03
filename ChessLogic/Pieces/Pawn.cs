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

        
        if(Row + direction <= 7 && Row + direction >= 0)
        {
            // Ruch do przodu
            Tile forwardTile = board.GetTile(Row + direction, Col);
            if (forwardTile.Piece == null)
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
        }


        // Bicie
        int[] attackOffsets = { -1, 1 };
        foreach (int offset in attackOffsets)
        {
            int attackCol = Col + offset;
            if (attackCol >= 0 && attackCol <= 7)
            {
                Tile attackTile = board.GetTile(Row + direction, attackCol);
                if (attackTile.Piece != null && attackTile.Piece.Color != this.Color)
                {
                    possibleMoves.Add(attackTile);
                }
            }
        }

        return possibleMoves;
    }

    public override List<Tile> GetGuardedTiles(Board board)
    {
        List<Tile> guardedTiles = new List<Tile>();
        int[] attackOffsets = { -1, 1 };
        int direction = Color == 'w' ? -1 : 1; // Kierunek ruchu zależny od koloru
        foreach (int offset in attackOffsets)
        {
            int attackCol = Col + offset;
            if (attackCol >= 0 && attackCol <= 7)
            {
                Tile attackTile = board.GetTile(Row + direction, attackCol);
                guardedTiles.Add(attackTile);
            }
        }
        return guardedTiles;
    }
}