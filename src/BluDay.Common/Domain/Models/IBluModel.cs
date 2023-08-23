using System;

namespace BluDay.Common.Domain.Models
{
    public interface IBluModel : IEquatable<Model>
    {
        Guid Id { get; set; }

        DateTime? CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}