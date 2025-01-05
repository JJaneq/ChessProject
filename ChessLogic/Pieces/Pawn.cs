namespace Chess.ChessLogic;

public class Pawn : Piece
{
    public int canGetEnPassanted { get; set; } = 2; // Wartość domyślna
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
                    if (doubleForwardTile.Piece == null)
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
        
        // Bicie w przelocie

        int enPassantRow = Color == 'w' ? 3 : 4; // Rząd, na którym może zostać wykonane bicie w przelocie (4 dla białych, 3 dla czarnych)
        if (Row == enPassantRow)
        {
            // Sprawdź, czy pion przeciwnika zrobił podwójny ruch
            if(Row + direction <= 7 && Row + direction >= 0 && Col + 1 <= 7)
            {
                if (board.GetTile(Row, Col + 1).Piece is Pawn opponentPawn2 && opponentPawn2.Color != Color && opponentPawn2.Row == Row && opponentPawn2.Col == Col + 1 && opponentPawn2.canGetEnPassanted == 1)
                {
                    possibleMoves.Add(board.GetTile(Row + direction, Col + 1)); // Dodaj pole, na które można wykonać bicie w przelocie
                }
            }
            if (Row + direction <= 7 && Row + direction >= 0 && Col - 1 >= 0)
            {
                if (board.GetTile(Row, Col - 1).Piece is Pawn opponentPawn && opponentPawn.Color != Color && opponentPawn.Row == Row && opponentPawn.Col == Col - 1 && opponentPawn.canGetEnPassanted == 1)
                {
                    possibleMoves.Add(board.GetTile(Row + direction, Col - 1)); // Dodaj pole, na które można wykonać bicie w przelocie
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