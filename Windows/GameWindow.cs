using System.Media;
using System.Resources;
using System.Security.Cryptography;
using System.Windows.Forms;
using Chess.ChessLogic;

namespace Chess;

public partial class GameWindow : Form
{
    private Board board;
    private Game game;
    private BoardGraphic boardGraphic;
    private List<List<Button>> tileList;
    private Menu menu;
    private List<MoveInfo> _moves;
    const int SIZE = 8;
    public GameWindow(Menu menuWindow)
    {
        InitializeComponent();
        //Identyczne wymiary okna niezależnie od skalowania ekranu
        ClientSize = new Size(1100, 965);
        boardPanel.Size = new Size(850, 850);

        board = new Board(SIZE);
        game = new Game(board);

        //Drawing board
        boardGraphic = new BoardGraphic();
        tileList = boardGraphic.DrawBoard(boardPanel, board, TileClick);
        board.SetStartPieces();
        boardGraphic.DrawPieces(boardPanel, board, tileList);
        
        menu = menuWindow;
        _moves = new List<MoveInfo>();
    }

    private void TileClick(object sender, EventArgs e)
    {
        if (!board.GameON)
        {
            return;
        }
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
        Console.WriteLine(board.GetTile(row, col).ToString());


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
            _moves.Add(new MoveInfo(board.SelectedTile.ToString(), to.ToString()));
            
            SoundPlayer moveSound = new SoundPlayer("Assets/piece_move.wav");
            moveSound.Play();
           if (to.Piece.CanBePromoted())
           {
               PromotionWindow promotionWindow= new PromotionWindow(to);
               promotionWindow.ShowDialog();
           }
            boardGraphic.HideMoves(tileList);
            boardGraphic.DrawPieces(boardPanel, board, tileList);
            board.SelectedTile = null;
        }

        if (board.GameON)
        {
            labelMove.Text = "Ruch: " + ((game.Turn == 'w') ? "białe" : "czarne");
        }
        else
        {
            labelMove.Text = "";
        }

        if (board.CheckMate)//na co komu switch case
        {
            labelCheck.Text = (game.Turn == 'w' ? "Czarny" : "Biały") + " wygrał przez mata";
        }
        else
        {
            if (board.Pat)
                labelCheck.Text = "Remis - Pat!";
            else
            {
                if (board.InsufficientMaterial)
                {
                    labelCheck.Text = "Remis - Brak materiału!";
                }
                else
                {
                    if (game.HalfMoveCounter >= 50)
                    {
                        labelCheck.Text = "Remis - Zasada 50 ruchów";
                    }
                    else
                    {
                        if (board.Check)
                            labelCheck.Text = (game.Turn == 'w' ? "Biały" : "Czarny") + " król jest szachowany";
                        else
                            labelCheck.Text = "";
                    }
                }
            }
        }
    }

    private void Form1_Closed(object sender, FormClosedEventArgs e)
    {
        var context = new ChessContext();
        //int gameId = (context.GameInfo.Any() ? context.GameInfo.Max(i => i.Id) : 0) + 1;
        context.GameInfo.Add(new GameHistory() {
            //Id = gameId,
            MoveHistory = _moves
        });
        context.SaveChanges();
        menu.Show();
    }
}