using System;

namespace BluDay.Common.Domain.Models
{
    public interface IBluModel : IEquatable<BluModel>
    {
        Guid Id { get; set; }

        DateTime? CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}