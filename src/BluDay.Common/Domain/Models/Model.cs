using System;

namespace BluDay.Common.Domain.Models
{
    public abstract class Model : Common.Types.BluObservableObject, IBluModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool Equals(Model model) => Id == model?.Id;
    }
}