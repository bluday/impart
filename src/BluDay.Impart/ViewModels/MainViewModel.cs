using BluDay.Common.Extensions;
using BluDay.Common.Services;
using BluDay.Common.Types;
using BluDay.Common.UI.Xaml.Input;
using BluDay.Impart.Events;
using BluDay.Impart.Models;
using BluDay.Impart.Services;
using System.Collections.Specialized;
using System.Windows.Input;

namespace BluDay.Impart.ViewModels
{
    public sealed class MainViewModel : Common.Domain.ViewModels.BluViewModel
    {
        private string _header;

        private ChatModel _currentChat;

        private UserModel _currentUser;

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public ChatModel CurrentChat
        {
            get => _currentChat;
            set => SetProperty(ref _currentChat, value);
        }

        public UserModel CurrentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        public BluResponsiveCollection<ChatModel> Chats { get; }

        public ICommand CreateChatCommand { get; private set; }
        
        public ICommand DeleteChatCommand { get; private set; }

        public MainViewModel(
            IBluCommonServices commonServices,
            IImpartUserService userService,
            IImpartChatService chatService
        )
            : base(commonServices)
        {
            CurrentUser = userService.CurrentUser;

            Chats = new BluResponsiveCollection<ChatModel>();

            Chats.BluAddRange(chatService.Chats);

            CurrentChat = chatService.CurrentChat;
        }

        private bool CanModifyChat(ChatModel chat)
        {
            return !(chat is null) && Chats.Contains(chat);
        }

        private void CreateChat(object parameter)
        {
            Chats.Add(new ChatModel());
        }

        private void DeleteChat(ChatModel chat)
        {
            if (chat is null) return;

            Chats.Remove(chat);
        }

        private void OnCurrentChatChanged()
        {
            if (CurrentChat is null) return;

            Notify(new ChatLaunchRequestEvent(CurrentChat));
        }

        private void OnChatLaunched(ChatLaunchedEvent e)
        {
            CurrentChat = e.Chat;
        }

        private void OnCurrentUserUpdated(CurrentUserUpdatedEvent e)
        {
            CurrentUser = e.User;
        }

        private void Chats_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            var chat = (args.NewItems ?? args.OldItems)[0] as ChatModel;

            if (args.Action is NotifyCollectionChangedAction.Add)
            {
                Notify(new ChatCreatedEvent(chat));
            }
            else if (args.Action is NotifyCollectionChangedAction.Remove)
            {
                Notify(new ChatDeletedEvent(chat));
            }
        }

        private void Chats_CollectionChanging(object sender, NotifyCollectionChangedEventArgs args)
        {
            var chat = (args.NewItems ?? args.OldItems)[0] as ChatModel;

            if (args.Action is NotifyCollectionChangedAction.Remove)
            {
                CurrentChat = Chats.BluNextOrPrevious(chat);
            }
        }

        protected override void ConfigureCommands()
        {
            base.ConfigureCommands();

            CreateChatCommand = new BluCommand(CreateChat);

            DeleteChatCommand = new BluCommand<ChatModel>(DeleteChat, CanModifyChat);
        }

        protected override void ConfigureSubscriptions()
        {
            base.ConfigureSubscriptions();

            Subscribe<ChatLaunchedEvent>(OnChatLaunched);
            Subscribe<CurrentUserUpdatedEvent>(OnCurrentUserUpdated);
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == nameof(CurrentChat))
            {
                OnCurrentChatChanged();
            }

            base.OnPropertyChanged(name);
        }

        protected override void RegisterEventHandlers()
        {
            Chats.CollectionChanged  += Chats_CollectionChanged;
            Chats.CollectionChanging += Chats_CollectionChanging;
        }

        protected override void UnregisterEventHandlers()
        {
            Chats.CollectionChanged  -= Chats_CollectionChanged;
            Chats.CollectionChanging -= Chats_CollectionChanging;
        }
    }
}