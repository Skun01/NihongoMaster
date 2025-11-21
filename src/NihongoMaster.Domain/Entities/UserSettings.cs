using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class UserSettings
{
    [Key]
    public int UserId {set; get;}

    [ForeignKey("UserId")]
    public virtual User? User {set; get;}
    public bool EnableGhostMode {set; get;} = true;
    public int DailyGoal {set; get;} = 10;

    [MaxLength(5)]
    public SupportedLanguage UiLanguage {set; get;} = SupportedLanguage.Vietnamese;
    public bool NotificationEnable {set; get;} = true;
}
