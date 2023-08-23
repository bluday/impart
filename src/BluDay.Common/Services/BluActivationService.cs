using BluDay.Common.Extensions;
using BluDay.Common.Events;

namespace BluDay.Common.Services
{
    public sealed class BluActivationService : BluService, IBluActivationService
    {
        public bool Activated { get; private set; }

        public string Arguments { get; private set; }

        public BluActivationService(IBluCommonServices commonServices) : base(commonServices) { }

        private void OnWindowActivated(WindowActivatedEvent e)
        {
            Publish(new DefaultViewNavigationRequestEvent());

            Activated = true;

            Logger.LogSuccess("App activation complete.");
        }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<WindowActivatedEvent>(OnWindowActivated);
        }

        public void Activate(string arguments)
        {
            if (Activated) return;

            Arguments = arguments;

            Publish(new WindowActivationRequestEvent());
        }
    }
}