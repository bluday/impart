using BluDay.Common.Extensions;
using BluDay.Common.Types;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Xaml.Media;

namespace BluDay.Impart.Models
{
    public sealed class ChatModel : Common.Domain.Models.Model
    {
        private bool _isGroup;

        private int _unreadCount;

        private string _avatarImageUrl, _title;

        public MessageModel LatestMessage => Messages.BluLast();

        public bool IsGroup
        {
            get => _isGroup;
            set => SetProperty(ref _isGroup, value);
        }

        public int UnreadCount
        {
            get => _unreadCount;
            set => SetProperty(ref _unreadCount, value);
        }

        public string Title
        {
            get => _title;
            set
            {
                value = value.BluOr(Common.BluConstants.Untitled);

                SetProperty(ref _title, value);
            }
        }

        public string AvatarImageUrl
        {
            get => _avatarImageUrl;
            set => SetProperty(ref _avatarImageUrl, value);
        }

        public ImageSource AvatarImage { get; set; }

        public Collection<Guid> MemberIds { get; set; }

        public Collection<Guid> MessageIds { get; set; }

        public BluResponsiveCollection<UserModel> Members { get; }

        public BluResponsiveCollection<MessageModel> Messages { get; }

        public ChatModel()
        {
            MemberIds  = new Collection<Guid>();
            MessageIds = new Collection<Guid>();

            Members  = new BluResponsiveCollection<UserModel>();
            Messages = new BluResponsiveCollection<MessageModel>();

            Messages.CollectionChanged += Messages_CollectionChanged;
        }

        public ChatModel(string title) : this()
        {
            Title = title;
        }

        ~ChatModel()
        {
            Messages.CollectionChanging -= Messages_CollectionChanged;
        }

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            OnPropertyChanged(nameof(LatestMessage));
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == nameof(AvatarImageUrl))
            {
                AvatarImage = AvatarImageUrl?.BluToBitmapImage();

                OnPropertyChanged(nameof(AvatarImage));
            }

            base.OnPropertyChanged(name);
        }
    }
}