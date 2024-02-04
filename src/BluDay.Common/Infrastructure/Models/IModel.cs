namespace BluDay.Common.Infrastructure.Models;

public interface IModel
{
    Guid Id { get; init; }

    DateTime? CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }

    DateTime? DeletedAt { get; set; }
}