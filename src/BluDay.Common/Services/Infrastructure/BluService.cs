using BluDay.Common.Logging;
using BluDay.Common.Messaging;
using BluDay.Common.Events;

namespace BluDay.Common.Services
{
    public abstract class BluService : IBluService
    {
        public bool Disposed { get; private set; }

        protected IBluLogger Logger { get; }

        protected IBluEventAggregator EventAggregator { get; }

        public BluService(IBluCommonServices commonServices)
        {
            Logger = commonServices?.LoggerService.Create(target: this);

            EventAggregator = commonServices?.EventAggregator;

            ConfigureSubscriptions();

            RegisterEventHandlers();
        }

        protected void Publish<TEvent>(TEvent e) where TEvent : IBluEvent
        {
            EventAggregator?.PublishAsync(this, e);
        }

        protected void Publish<TEvent>(string topicName, TEvent e) where TEvent : IBluEvent
        {
            EventAggregator?.PublishAsync(topicName, this, e);
        }

        protected void Subscribe<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventAggregator?.SubscribeAsync(handler);
        }

        protected void Subscribe<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventAggregator?.SubscribeAsync(topicName, handler);
        }

        protected void Unsubscribe()
        {
            EventAggregator?.UnsubscribeAsync(this);
        }

        protected void Unsubscribe<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventAggregator?.UnsubscribeAsync(handler);
        }

        protected void Unsubscribe<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            EventAggregator?.UnsubscribeAsync(topicName, handler);
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