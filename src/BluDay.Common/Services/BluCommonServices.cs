using BluDay.Common.Messaging;

namespace BluDay.Common.Services
{
    public sealed class BluCommonServices : IBluCommonServices
    {
        public IBluEventAggregator EventAggregator { get; }

        public IBluLoggerService LoggerService { get; }

        public BluCommonServices(IBluEventAggregator eventAggregator, IBluLoggerService loggerService)
        {
            EventAggregator = eventAggregator;
            LoggerService   = loggerService;
        }
    }
}