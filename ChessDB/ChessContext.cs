using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace Chess;

public class ChessContext : DbContext
{
    public DbSet<MoveInfo> Moves { get; set; }
    public DbSet<GameHistory> GameInfo { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<MoveInfo>()
          //  .HasKey(e => e.Id); // Klucz główny

        // Konfiguracja automatycznego generowania ID przez bazę danych
        modelBuilder.Entity<MoveInfo>()
            .Property(e => e.MoveId)
            .ValueGeneratedOnAdd(); // Ustawienie automatycznego generowania ID
        
        modelBuilder.Entity<GameHistory>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd(); // Ustawienie automatycznego generowania ID
    }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=msdb;Trusted_Connection=True;TrustServerCertificate=True");
    }
}