using System;
using System.ComponentModel.DataAnnotations;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Domain.Entities;

public class User
{
    [Key]
    public int Id {set; get;}

    [Required]
    [MaxLength(50)]
    public string Username {set; get;} = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email {set; get;} = string.Empty;

    [Required]
    public string PasswordHash {set; get;} = string.Empty;

    [MaxLength(20)]
    public UserRole Role {set; get;} = UserRole.Learner;
    public bool IsActive{set; get;} = true;
    public DateTime CreatedAt {set; get;}

    // RELATIONSHIP
    // 1 - 1 to UserSettings
    public virtual UserSettings? UserSettings {set; get;}

    // 1 - N to Decks
    public virtual ICollection<Deck> Decks {set; get;} = [];
    
}
