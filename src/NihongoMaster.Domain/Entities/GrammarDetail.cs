using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class GrammarDetail
{
    [Key]
    public int CardId {set; get;}
    
    [ForeignKey("CardId")]
    public virtual Card? Card {set; get;}

    public string? Structure {set; get;} = string.Empty;
    public string? Explanation {set; get;} = string.Empty;
    public string? Caution {set; get;} = string.Empty;
    public JLPTLevel Level {set; get;} = JLPTLevel.N5;
}
