namespace BluDay.Common.Services
{
    public interface IBluCommonServices
    {
        IBluEventService EventService { get; }

        IBluLoggerService LoggerService { get; }
    }
}