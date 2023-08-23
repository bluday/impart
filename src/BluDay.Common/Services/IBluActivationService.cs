namespace BluDay.Common.Services
{
    public interface IBluActivationService
    {
        bool Activated { get; }

        string Arguments { get; }
        
        void Activate(string arguments);
    }
}