using BluDay.Common.DependencyInjection;
using BluDay.Common.DependencyInjection.Extensions;
using BluDay.Common.Extensions;
using BluDay.Common.Logging;
using BluDay.Common.Messaging;
using BluDay.Common.Services;
using BluDay.Impart.Services;

namespace BluDay.Impart
{
    public sealed class ImpartCore
    {
        private readonly IBluContainer _container;

        private readonly IBluLogger _logger;

        private readonly IImpartConfig _config;

        public bool Disposed { get; private set; }

        public bool Initialized { get; private set; }

        public ImpartCore()
        {
            _container = CreateContainer();

            _logger = BluLoggerFactory.Create(target: this);

            _config = _container.Resolve<IImpartConfig>();
        }

        private BluContainer CreateContainer()
        {
            return new BluServiceCollection()
                // Singletons.
                .AddSingleton<IBluEventAggregator,      BluEventAggregator>()
                .AddSingleton<IBluActivationService,    BluActivationService>()
                .AddSingleton<IBluLoggerService,        BluLoggerService>()
                .AddSingleton<IBluNavigationService,    BluNavigationService>()
                .AddSingleton<IBluViewRegistryService,  BluViewRegistryService>()
                .AddSingleton<IBluViewResolverService,  BluViewResolverService>()
                .AddSingleton<IBluWindowService,        BluWindowService>()
                .AddSingleton<IBluCommonServices,       BluCommonServices>()
                .AddSingleton<IImpartConfig,            ImpartConfig>()
                .AddSingleton<IImpartChatService,       ImpartChatService>()
                .AddSingleton<IImpartUserService,       ImpartUserService>()
                .AddSingleton<IImpartSampleDataService, ImpartSampleDataService>()
                // Transients.
                .AddTransient<IBluDialogService,       BluDialogService>()
                .AddTransient<IBluFilePickerService,   BluFilePickerService>()
                .AddTransient<IBluNotificationService, BluNotificationService>()
                // Let's fly!
                .BuildContainer();
        }

        public void Dispose()
        {
            if (Disposed) return;

            _logger.LogInfo("Disposing...");

            _container.Dispose();

            _logger.LogSuccess("Disposed");

            Disposed = true;
        }

        public void Initialize(string launchArgs)
        {
            if (Initialized) return;

            _logger.LogInfo("Initializing...");

            _container
                .Initialize<IBluWindowService>()
                .Initialize<IBluNavigationService>()
                .Initialize<IBluViewRegistryService>()
                .Initialize<IBluViewResolverService>()
                .Initialize<IImpartChatService>()
                .Initialize<IImpartUserService>()
                .Initialize<IImpartSampleDataService>();

            _container
                .Resolve<IBluActivationService>()
                .Activate(launchArgs);

            _logger.LogSuccess("Initialized.");

            Initialized = true;
        }
    }
}