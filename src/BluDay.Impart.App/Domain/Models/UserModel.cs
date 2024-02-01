namespace BluDay.Impart.App.Domain.Models;

public sealed class UserModel : Model
{
    [Required]
    [MaxLength(1024)]
    [MinLength(1)]
    public string Username { get; set; } = null!;
}