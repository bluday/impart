namespace BluDay.Common.Types
{
    public interface IBluDisposable
    {
        bool Disposed { get; }

        void Dispose();
    }
}