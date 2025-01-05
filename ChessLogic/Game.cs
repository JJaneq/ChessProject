using System.Runtime.Intrinsics.Arm;

namespace Chess.ChessLogic;

public class Game
{
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Board Board { get; set; }
    public char Turn { get; set; }
    // public Boolean Check { get; private set; }
    
    public Game(Board board)
    {
        Board = board;
        Player1 = new Player('w');
        Player2 = new Player('b');

        Turn = 'w';
        //Check = false;
    }

    private void NextTurn()
    {
        foreach (var tile in Board.Tiles)
        {
            if (tile.Piece is Pawn pawn)
            {
                if (pawn.Moved)
                {
                    pawn.canGetEnPassanted--;
                }
            }
        }
        Turn = Turn == 'w' ? 'b' : 'w';
        Board.isKingChecked(Turn);
    }

    public void MovePiece(Tile from, Tile to)
    {
        // Sprawdź, czy to roszada krótka
        if (from.Piece is King && Math.Abs(to.Column - from.Column) == 2)
        {
            if (to.Column > from.Column) // Roszada krótka
            {
                Tile rookTile = Board.GetTile(from.Row, from.Column + 3); // Pole wieży
                Tile rookTargetTile = Board.GetTile(from.Row, from.Column + 1); // Docelowe pole wieży
                rookTargetTile.Piece = rookTile.Piece;
                rookTile.Piece = null;
                rookTargetTile.Piece.Col = rookTargetTile.Column;
            }
            else // Roszada długa
            {
                Tile rookTile = Board.GetTile(from.Row, from.Column - 4); // Pole wieży
                Tile rookTargetTile = Board.GetTile(from.Row, from.Column - 1); // Docelowe pole wieży
                rookTargetTile.Piece = rookTile.Piece;
                rookTile.Piece = null;
                rookTargetTile.Piece.Col = rookTargetTile.Column;
            }
        }

        //EnPassant
        if (from.Piece is Pawn pawn && to.Piece == null && Math.Abs(from.Column - to.Column) == 1 && Math.Abs(from.Row - to.Row) == 1)
        {
            // Usuwanie piona przeciwnika znajdującego się w sąsiedniej kolumnie
            if(from.Column + 1 <= 7)
            {
                Tile rightAdjacentTile = Board.GetTile(from.Row, from.Column + 1);
                if (rightAdjacentTile.Piece is Pawn rightAdjacentPawn && rightAdjacentPawn.Color != pawn.Color && rightAdjacentPawn.canGetEnPassanted == 1)
                {
                    rightAdjacentTile.Piece = null; // Usuń pion przeciwnika
                }
            }
            if (from.Column - 1 >= 0)
            {
                Tile leftAdjacentTile = Board.GetTile(from.Row, from.Column - 1);
                if (leftAdjacentTile.Piece is Pawn leftAdjacentPawn && leftAdjacentPawn.Color != pawn.Color && leftAdjacentPawn.canGetEnPassanted == 1)
                {
                    leftAdjacentTile.Piece = null; // Usuń pion przeciwnika
                }
            }
        }

        to.Piece = from.Piece;
        from.Piece = null;
        
        to.Piece.Row = to.Row;
        to.Piece.Col = to.Column;
        to.Piece.Moved = true;
        
        NextTurn();
    }
    
    public Boolean CheckMove(Tile from, Tile to)
    {
        List<Tile> availableTiles = from.Piece.RemoveBlockedMoves(Board, from.Piece.GetPossibleMoves(Board));
        if (availableTiles.Contains(to))
        {
            return true;
        }
        return false;
    }
}