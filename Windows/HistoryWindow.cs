using System.CodeDom;

namespace Chess;

public partial class HistoryWindow : Form
{
    Menu _menu;
    public HistoryWindow(Menu menu)
    {
        InitializeComponent();
        _menu = menu;
    }

    private void HistoryWindow_Load(object sender, EventArgs e)
    {
        Console.WriteLine("Ładowanie historii");
        ChessContext context = new ChessContext();
        List<GameHistory> gamesInfo = context.GameInfo.ToList();
        foreach (var game in gamesInfo)
        {
            GameList.Items.Add(game.Id + " : " + game.Result);
        }
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
        _menu.Close();
    }

    private void GameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChessContext context = new ChessContext();
        var moveList = context.Moves.Where(m => m.GameHistoryId == GameList.SelectedIndex + 1).ToList();

        if (moveList != null)
        {
            string moveText = "";

            for (int i = 0; i < moveList.Count; i++)
            {
                moveText += (i + 1) + ". " + moveList[i].From + " ->" + moveList[i].To + " : " + moveList[i].MoveTime +'\n';
            }
            
            historyLabel.Text = moveText;
        }
        else
        {
            throw new Exception("Incorrect GameInfo index selected.");
        }
    }
}