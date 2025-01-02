using System.Resources;
using System.Security.Cryptography;
using Chess.ChessLogic;

namespace Chess;

public partial class Form1 : Form
{
    private Board board;
    private Game game;
    BoardGraphic boardGraphic;
    private List<List<Button>> tileList;
    const int SIZE = 8;
    public Form1()
    {
        InitializeComponent();

        board = new Board(SIZE);
        game = new Game(board);

        //Drawing board
        boardGraphic = new BoardGraphic();
        tileList = boardGraphic.DrawBoard(boardPanel, board, TileClick);
        board.SetStartPieces();
        boardGraphic.DrawPieces(boardPanel, board, tileList);
    }

    private void TileClick(object sender, EventArgs e)
    {
        boardGraphic.HideMoves(tileList);
        Button tile = (Button)sender;

        int row = -1, col = -1;
        if (tile.Tag is Point pos)
        {
            row = pos.X;
            col = pos.Y;
        }

        if (row == -1)
        {
            throw new InvalidDataException();
        }
        Console.WriteLine("Tile:" + row + "," + col);


        if (board.SelectedTile == null)
        {
            var piece = board.GetPiece(row, col);
            if (piece != null)
            {
                Tile selectedTile = board.GetTile(row, col);

                if (selectedTile.Piece.Color != game.Turn)
                {
                    return;
                }

                board.SelectedTile = selectedTile;
                boardGraphic.ShowMoves(board, tileList, selectedTile);
            }
        }
        else if (board.SelectedTile == board.GetTile(row, col))
        {
            boardGraphic.HideMoves(tileList);
            board.SelectedTile = null;
        }
        else
        {
            Tile to = board.GetTile(row, col);
            if (board.SelectedTile != null && to.Piece != null)
            {
                if (board.SelectedTile.Piece.Color == to.Piece.Color)
                {
                    board.SelectedTile = to;
                    boardGraphic.HideMoves(tileList);
                    boardGraphic.ShowMoves(board, tileList, board.SelectedTile);
                    return;
                }
            }
            if (!game.CheckMove(board.SelectedTile, to))
            {
                return;
            }
            game.MovePiece(board.SelectedTile, to);
            boardGraphic.HideMoves(tileList);
            boardGraphic.DrawPieces(boardPanel, board, tileList);
            board.SelectedTile = null;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void boardPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}