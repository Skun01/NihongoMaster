using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NihongoMaster.Domain.Entities;

public class DeckTag
{
    [Key]
    public int Id {set; get;}

    public int DeckId {set; get;}
    [ForeignKey("DeckId")]
    public virtual Deck? Deck {set; get;}

    [Required]
    [MaxLength(50)]
    public string TagName {set; get;} = string.Empty;
}
