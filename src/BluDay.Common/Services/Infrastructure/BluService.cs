using BluDay.Common.Logging;
using BluDay.Common.Messaging;
using BluDay.Common.Events;

namespace BluDay.Common.Services
{
    public abstract class BluService : IBluService
    {
        public bool Disposed { get; private set; }

        protected IBluLogger Logger { get; }

        protected IBluEventService EventService { get; }

        public BluService(IBluCommonServices commonServices)
        {
            Logger = commonServices?.LoggerService.Create(target: this);

            EventService = commonServices?.EventService;

            ConfigureSubscriptions();

            RegisterEventHandlers();
        }

        protected void Notify<TEvent>(TEvent e) where TEvent : IBluEvent
        {
            EventService?.NotifyAsync(this, e);
        }

        protected void Notify<TEvent>(string topicName, TEvent e) where TEvent : IBluEvent
        {
            EventService?.NotifyAsync(topicName, this, e);
        }

        protected void Subscribe<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventService?.SubscribeAsync(handler);
        }

        protected void Subscribe<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventService?.SubscribeAsync(topicName, handler);
        }

        protected void Unsubscribe()
        {
            EventService?.UnsubscribeAsync(this);
        }

        protected void Unsubscribe<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventService?.UnsubscribeAsync(handler);
        }

        protected void Unsubscribe<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventService?.UnsubscribeAsync(topicName, handler);
        }

        protected virtual void ConfigureSubscriptions() { }

        protected virtual void RegisterEventHandlers() { }

        protected virtual void UnregisterEventHandlers() { }

        public void Dispose()
        {
            if (Disposed) return;

            UnregisterEventHandlers();

            Disposed = true;
        }
    }
}