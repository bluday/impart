using Windows.ApplicationModel.Activation;

namespace BluDay.Impart
{
    sealed partial class App : Windows.UI.Xaml.Application
    {
        private readonly ImpartCore _core = new ImpartCore();

        public App() => InitializeComponent();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            _core.Initialize(args.Arguments);
        }
    }
}