using System.Collections.Generic;

namespace BluDay.Common.Types
{
    public sealed class BluHierarchySection<T> where T : class
    {
        public T Parent { get; }

        public IReadOnlyList<T> Children { get; }

        public BluHierarchySection(T parent, IReadOnlyList<T> children)
        {
            BluValidator.NotNull(parent, nameof(parent));

            children = children ?? new List<T>();

            foreach (T child in children)
            {
                BluValidator.NotNull(child, nameof(child));

                if (child == Parent)
                {
                    throw new System.InvalidOperationException("Child should not be the parent.");
                }
            }

            Parent = parent;

            Children = children;
        }
    }
}