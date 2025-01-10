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
            GameList.Items.Add("Game " + game.Id + " : " + game.GetEndTime());
        }
    }
}