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
        Turn = Turn == 'w' ? 'b' : 'w';
        Board.isKingChecked(Turn);
    }

    public void MovePiece(Tile from, Tile to)
    {
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