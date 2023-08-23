namespace BluDay.Common.Services
{
    public interface IBluCommonServices
    {
        Messaging.IBluEventAggregator EventAggregator { get; }

        IBluLoggerService LoggerService { get; }
    }
}