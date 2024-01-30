namespace Impart.Core.Domain.Models;

public sealed class UserModel : Model
{
    [DisallowNull]
    [Required]
    [MaxLength(1024)]
    [MinLength(1)]
    public string Username { get; set; } = null!;
}