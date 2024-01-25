namespace Impart.Core.Domain.Models;

[UniqueModel]
[TimestampedModel]
public sealed class UserModel : Model
{
    [DisallowNull]
    [Required]
    [MaxLength(1024)]
    [MinLength(1)]
    public string Username { get; set; } = null!;
}