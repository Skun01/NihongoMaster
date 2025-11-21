using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class Deck
{
    [Key]
    public int Id {set; get;}

    public int UserId {set; get;}
    [ForeignKey("UserId")]
    public virtual User? User {set; get;}

    [Required]
    [MaxLength(150)]
    public string Name {set; get;} = string.Empty;

    public string? Description {set; get;} 

    [Required]
    [MaxLength(20)]
    public DeckType Type {set; get;} = DeckType.Vocabulary;

    public bool IsPublic {set; get;} = false;
    
    public int? ParentDeckId {set; get;}
    public int TotalCards {set; get;} = 0;
    public int Downloads {set; get;} = 0;
    public DateTime CreatedAt {set; get;} = DateTime.UtcNow;

    // RElATIONSHIP
    // 1 - N to DeckTag
    public virtual ICollection<DeckTag> DeckTags {set; get;} = [];
    
    // 1 - N to Card
    public virtual ICollection<Card> Cards {set; get;} = [];

}   
