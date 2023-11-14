namespace BluDay.Common.Services
{
    public sealed class BluCommonServices : IBluCommonServices
    {
        public IBluEventService EventService { get; }

        public IBluLoggerService LoggerService { get; }

        public BluCommonServices(IBluEventService eventService, IBluLoggerService loggerService)
        {
            EventService  = eventService;
            LoggerService = loggerService;
        }
    }
}