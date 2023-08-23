using BluDay.Common.Messaging;
using BluDay.Common.Services;
using BluDay.Common.Events;
using BluDay.Common.UI.Xaml.Input;
using System.Windows.Input;

namespace BluDay.Common.Domain.ViewModels
{
    public abstract class BluViewModel : Types.BluObservableObject, IBluViewModel
    {
        protected Logging.IBluLogger Logger { get; }

        protected IBluEventAggregator EventAggregator { get; }

        protected IBluNavigationService NavigationService { get; }

        public bool Disposed { get; private set; }

        public ICommand NavigateCommand { get; private set; }

        public BluViewModel() { }

        public BluViewModel(IBluCommonServices commonServices)
        {
            Logger = commonServices?.LoggerService.Create(target: this);

            EventAggregator = commonServices?.EventAggregator;

            NavigateCommand = new BluCommand(Navigate, CanNavigate);

            ConfigureCommands();
            ConfigureSubscriptions();

            RegisterEventHandlers();
        }

        private bool CanNavigate(object viewPropertyValue)
        {
            return !(viewPropertyValue is null);
        }

        protected void Navigate(object viewPropertyValue)
        {
            Publish(new NavigationRequestEvent(viewPropertyValue));
        }

        protected void Navigate<TViewPropertyValue>()
        {
            Publish(new NavigationRequestEvent(typeof(TViewPropertyValue)));
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

        protected virtual void ConfigureCommands() { }

        protected virtual void ConfigureSubscriptions() { }

        protected virtual void RegisterEventHandlers() { }

        protected virtual void UnregisterEventHandlers() { }

        public void Dispose()
        {
            if (Disposed) return;

            Unsubscribe();

            UnregisterEventHandlers();

            Disposed = false;
        }
    }
}