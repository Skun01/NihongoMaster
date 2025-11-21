using System;
using Microsoft.EntityFrameworkCore;
using NihongoMaster.Domain.Entities;

namespace NihongoMaster.Infrastructure.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users {set; get;}
    public DbSet<UserSettings> UserSettings { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<DeckTag> DeckTags { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<GrammarDetail> GrammarDetails { get; set; }
    public DbSet<CardExample> CardExamples { get; set; }
    public DbSet<UserCardProgress> UserCardProgresses { get; set; }
    public DbSet<StudyLog> StudyLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // FLUENT API

        // 1 - 1 relationship: User - UserSettings
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserSettings)
            .WithOne(us => us.User)
            .HasForeignKey<UserSettings>(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1 - 1 relationship: Card - GrammarDetail
        modelBuilder.Entity<Card>()
            .HasOne(c => c.GrammarDetail)
            .WithOne(gd => gd.Card)
            .HasForeignKey<GrammarDetail>(gd => gd.CardId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // FIX CYCLE CASCADE PATHS
        // block Cascade Delete to UserCardProgress
        modelBuilder.Entity<UserCardProgress>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction); // Delete User doesn't auto Delete progress (Avoid conflix with Card)

        // Chặn Cascade Delete cho StudyLogs
        modelBuilder.Entity<StudyLog>()
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction); // Delete User doesn't auto Delete Study log (Avoid conflix with Card)


        // CONFIGURE UNIQUE INDEX

        // one Deck must not have the same tag
        modelBuilder.Entity<DeckTag>()
            .HasIndex(t => new {t.DeckId, t.TagName})
            .IsUnique();

        // one User has only one User Progress for a Card
        modelBuilder.Entity<UserCardProgress>()
            .HasIndex(p => new {p.UserId, p.CardId})
            .IsUnique();


        // CONFIGURE ENUM TYPES
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Deck>()
            .Property(d => d.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Card>()
            .Property(c => c.Type)
            .HasConversion<string>();
        
        modelBuilder.Entity<GrammarDetail>()
            .Property(gd => gd.Level)
            .HasConversion<string>();
        
        modelBuilder.Entity<UserSettings>()
            .Property(us => us.UiLanguage)
            .HasConversion<string>();
        
    }
}
