namespace Chess;

public class GameHistory
{
    public int Id { get; set; }
    public List<MoveInfo> MoveHistory { get; set; }
    public string Result { get; set; }

    // public GameHistory(int gameId, List<MoveInfo> moveHistory)
    // {
    //     Id = gameId;
    //     MoveHistory = moveHistory;
    // }

    public DateTime GetEndTime()
    {
        return MoveHistory.Last().MoveTime;
    }
}