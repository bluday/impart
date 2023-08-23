namespace BluDay.Common.Services
{
    public interface IBluWindowService
    {
        bool Activated { get; }

        void Activate();

        void Close();
    }
}