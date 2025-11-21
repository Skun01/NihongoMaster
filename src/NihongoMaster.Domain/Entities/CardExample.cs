using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NihongoMaster.Domain.Entities;

public class CardExample
{
    [Key]
    public int Id {set; get;}

    public int CardId {set; get;}
    [ForeignKey("CardId")]
    public virtual Card? Card {set; get;}

    [Required]
    [MaxLength(500)]
    public string SentenceJapanese {set; get;} = string.Empty;

    [Required]
    [MaxLength(500)]
    public string SentenceMeaning {set; get;} = string.Empty;

    [MaxLength(100)]
    public string? ClozePart {set; get;}

    [MaxLength(200)]
    public string? AlternativeAnswers {set; get;}

    [MaxLength(255)]
    public string? AudioUrl {set; get;}
}
