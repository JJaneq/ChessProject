using System.ComponentModel.DataAnnotations;
using Chess.ChessLogic;
using Microsoft.EntityFrameworkCore;

namespace Chess;

public class MoveInfo
{
    [Key]
    public int MoveId;
    public string From { get; set; } 
    public string To { get; set; }
    public DateTime MoveTime { get; set; }

    public MoveInfo(string from, string to)
    {
        ChessContext context = new ChessContext();
        //MoveId = (context.Moves.Any() ? context.Moves.Max(i => i.MoveId) : 0) + 1;
        context.SaveChanges();
        From = from;
        To = to;
        MoveTime = DateTime.Now;
    }
}