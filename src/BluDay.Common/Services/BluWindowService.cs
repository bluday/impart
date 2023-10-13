namespace BluDay.Common.Services
{
    public sealed class BluWindowService : BluService, IBluWindowService
    {
        public bool MainWindowIsActivated { get; }

        public BluWindowService(IBluCommonServices commonServices) : base(commonServices) { }

        protected override void ConfigureSubscriptions()
        {
            // Need a subscription-until-triggered feature.
            // Subscribe<WindowActivationRequestEvent>(OnWindowActivationRequest);
        }
    }
}