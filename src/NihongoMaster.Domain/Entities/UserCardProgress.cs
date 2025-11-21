using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class UserCardProgress
{
    [Key]
    public int Id {set; get;}

    public int UserId {set; get;}
    [ForeignKey("UserId")]
    public virtual User? User {set; get;}

    public int CardId {set; get;}
    [ForeignKey("CardId")]
    public virtual Card? Card {set; get;}

    public SRSStage SRSLevel {set; get;} = SRSStage.New;

    public DateTime? NextReviewDate {set; get;}

    public int GhostLevel {set; get;} = 0;

    //Statistical
    public int Streak{set; get;} = 0;
    public DateTime LastReviewedDate{set; get;} = DateTime.UtcNow;
}
