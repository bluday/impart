namespace BluDay.Common.Types
{
    public interface IBluRelative<T> where T : class
    {
        T Parent { get; set; }

        System.Collections.Generic.IReadOnlyList<T> Children { get; set; }
    }
}