using BluDay.Common.Events;
using BluDay.Common.Extensions;
using BluDay.Common.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace BluDay.Common.Services
{
    public sealed class BluWindowService : Service, IBluWindowService
    {
        public bool Activated { get; private set; }

        private BluShell Shell { get; } = new BluShell();

        private Window Window => Window.Current;

        public BluWindowService(IBluCommonServices commonServices) : base(commonServices)
        {
            Window.Content = Shell;
        }

        private void OnWindowActivationRequest(WindowActivationRequestEvent e)
        {
            Unsubscribe<WindowActivationRequestEvent>(OnWindowActivationRequest);

            Activate();
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            Activated = true;

            Publish(new WindowActivatedEvent());

            Logger.LogSuccess("Window activated.");
        }

        private void Window_Closed(object sender, CoreWindowEventArgs args)
        {
            Logger.LogInfo("Window closed.");
        }

        protected override void ConfigureSubscriptions()
        {
            // Need a subscription-until-triggered feature.
            Subscribe<WindowActivationRequestEvent>(OnWindowActivationRequest);
        }

        protected override void RegisterEventHandlers()
        {
            Window.Activated += Window_Activated;
            Window.Closed    += Window_Closed;
        }

        protected override void UnregisterEventHandlers()
        {
            Window.Activated -= Window_Activated;
            Window.Closed    -= Window_Closed;
        }

        public void Activate()
        {
            if (Activated) return;

            Logger.LogInfo("Activating window...");

            Window.Activate();
        }

        public void Close()
        {
            if (!Activated) return;

            Logger.LogInfo("Closing window...");

            Window.Close();
        }
    }
}