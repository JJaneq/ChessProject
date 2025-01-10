using Chess.ChessLogic;

namespace Chess;

public partial class PromotionWindow : Form
{
    private char Color;
    private Tile CurrentTile;
    public PromotionWindow(Tile tile)
    {
        if (tile == null) throw new ArgumentNullException(nameof(tile));
        if (tile.Piece == null) throw new ArgumentNullException("No piece specified");
        InitializeComponent();
        Color = tile.Piece.Color;
        
        string colorName = Color == 'w' ? "white" : "black";
            
        QueenButton.BackgroundImage = Image.FromFile($"Assets/{colorName}_queen.png");
        RookButton.BackgroundImage = Image.FromFile($"Assets/{colorName}_rook.png");
        BishopButton.BackgroundImage = Image.FromFile($"Assets/{colorName}_bishop.png");
        KnightButton.BackgroundImage = Image.FromFile($"Assets/{colorName}_knight.png");
        
        CurrentTile = tile;
    }

    private void QueenButton_Click(object sender, EventArgs e)
    {
        CurrentTile.Piece = new Queen(Color, CurrentTile.Row, CurrentTile.Column);
        Close();
    }

    private void RookButton_Click(object sender, EventArgs e)
    {
        CurrentTile.Piece = new Rook(Color, CurrentTile.Row, CurrentTile.Column);
        Close();
    }

    private void BishopButton_Click(object sender, EventArgs e)
    {
        CurrentTile.Piece = new Bishop(Color, CurrentTile.Row, CurrentTile.Column);
        Close();
    }

    private void KnightButton_Click(object sender, EventArgs e)
    {
        CurrentTile.Piece = new Knight(Color, CurrentTile.Row, CurrentTile.Column);
        Close();
    }
}