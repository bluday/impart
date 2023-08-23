using BluDay.Common.Extensions;
using BluDay.Common.Types;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;

namespace BluDay.Impart.Models
{
    public sealed class UserModel : Common.Domain.Models.BluModel
    {
        private string
            _avatarImageUrl,
            _backgroundImageUrl,
            _displayName,
            _username;

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value.BluOr(null));
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value.BluOr(null));
        }

        public string AvatarImageUrl
        {
            get => _avatarImageUrl;
            set => SetProperty(ref _avatarImageUrl, value);
        }

        public string BackgroundImageUrl
        {
            get => _backgroundImageUrl;
            set => SetProperty(ref _backgroundImageUrl, value);
        }

        public ImageSource AvatarImage { get; private set; }

        public ImageSource BackgroundImage { get; private set; }

        public Collection<Guid?> ChatIds { get; set; }

        public BluResponsiveCollection<ChatModel> Chats { get; }

        public UserModel()
        {
            ChatIds = new Collection<Guid?>();

            Chats = new BluResponsiveCollection<ChatModel>();
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == nameof(AvatarImageUrl))
            {
                AvatarImage = AvatarImageUrl?.BluToBitmapImage();

                OnPropertyChanged(nameof(AvatarImage));
            }

            if (name == nameof(BackgroundImageUrl))
            {
                BackgroundImage = BackgroundImageUrl?.BluToBitmapImage();

                OnPropertyChanged(nameof(BackgroundImage));
            }

            base.OnPropertyChanged(name);
        }

        public override string ToString()
        {
            return "{0} ({1}, \"{2}\", \"{3}\")".BluFormat(
                nameof(UserModel),
                Id,
                Username    ?? Common.BluConstants.None,
                DisplayName ?? Common.BluConstants.None
            );
        }
    }
}