using BluDay.Common.Types;

namespace BluDay.Common.Extensions
{
    public static class BluExtensions
    {
        public static bool HasPredecessor<T>(this IBluRelative<T> source, T predecessor) where T : class
        {
            if (source is null)
            {
                return false;
            }

            if (source == predecessor)
            {
                return true;
            }

            var parent = source?.Parent as IBluRelative<T>;

            return parent.HasPredecessor(predecessor) is true;
        }

        public static bool HasSuccessor<T>(this IBluRelative<T> source, T successor) where T : class
        {
            if (source is null) return false;

            foreach (IBluRelative<T> child in source.Children)
            {
                if (child == successor || child.HasSuccessor(successor))
                {
                    return true;
                }
            }

            return false;
        }
    }
}