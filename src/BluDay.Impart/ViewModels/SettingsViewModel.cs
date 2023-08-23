using BluDay.Common.Extensions;
using BluDay.Common.Services;

namespace BluDay.Impart.ViewModels
{
    public sealed class SettingsViewModel : Common.Domain.ViewModels.BluViewModel
    {
        private string _version;

        public string Version
        {
            get         => _version;
            private set
            {
                value = value.BluOr(Common.BluConstants.NaN);

                SetProperty(ref _version, value);
            }
        }

        public string[] Themes { get; }

        public SettingsViewModel(IImpartConfig config, IBluCommonServices commonServices)
            : base(commonServices)
        {
            Themes = System.Enum.GetNames(typeof(Windows.UI.Xaml.ElementTheme));

            Version = config.AppInfo.Version;
        }
    }
}