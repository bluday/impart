using Windows.UI.Xaml.Media;

namespace BluDay.Impart.ViewModels
{
    public sealed class UserViewModel : Common.Domain.ViewModels.ViewModel
    {
        private string _displayName, _username;

        private ImageSource _avatarImage, _backgroundImage;

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public ImageSource AvatarImage
        {
            get => _avatarImage;
            set => SetProperty(ref _avatarImage, value);
        }

        public ImageSource BackgroundImage
        {
            get => _backgroundImage;
            set => SetProperty(ref _backgroundImage, value);
        }

        public UserViewModel(Common.Services.IBluCommonServices commonServices)
            : base(commonServices) { }
    }
}