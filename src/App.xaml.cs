using Windows.ApplicationModel.Activation;

namespace BluDay.Impart
{
    sealed partial class App : Windows.UI.Xaml.Application
    {
        private readonly ImpartCore _core = new ImpartCore();

        public LaunchActivatedEventArgs LaunchArgs { get; private set; }

        public App() => InitializeComponent();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            LaunchArgs = args;

            _core.Initialize(args.Arguments);
        }
    }
}