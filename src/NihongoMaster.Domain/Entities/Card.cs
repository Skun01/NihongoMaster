using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class Card
{
    [Key]
    public int Id {set; get;}

    public int DeckId {set; get;}
    [ForeignKey("DeckId")]
    public virtual Deck? Deck {set; get;}

    public CardType Type {set; get;} = CardType.Vocabulary;

    [Required]
    [MaxLength(200)]
    public string Term {set; get;} = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string Meaning {set; get;} = string.Empty;

    public string? Note {set; get;} = string.Empty;

    public DateTime CreatedAt {set; get;} = DateTime.UtcNow;

    // RELATIONSHIP
    // 1 - 1 to GrammarDetail
    public virtual GrammarDetail? GrammarDetail {set; get;}

    // 1 - N to CardExamples
    public virtual ICollection<CardExample> Examples {set; get;} = [];

    // 1 - N to UserCardProgress
    public virtual ICollection<UserCardProgress> Progresses {set; get;} = [];
}
