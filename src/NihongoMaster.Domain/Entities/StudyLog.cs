using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NihongoMaster.Domain.Entities;

public class StudyLog
{
    [Key]
    public int Id {set; get;}

    public int UserId {set; get;}
    [ForeignKey("UserId")]
    public virtual User? User {set; get;}

    public int CardId {set; get;}
    [ForeignKey("CardId")]
    public virtual Card? Card {set; get;}

    public DateTime ReviewDate {set; get; } = DateTime.UtcNow;
    public bool IsCorrect {set; get;}
}
