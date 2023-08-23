using BluDay.Common.Extensions;
using BluDay.Common.Services;
using BluDay.Common.UI.Xaml.Input;
using BluDay.Impart.Events;
using BluDay.Impart.Models;
using System.Collections.Specialized;
using System.Windows.Input;
using Windows.Storage;

namespace BluDay.Impart.ViewModels
{
    public sealed class ChatViewModel : Common.Domain.ViewModels.BluViewModel
    {
        private string _inputText;

        private ChatModel _chat;

        private IBluFilePickerService _filePickerService;

        public bool HasMessages => Chat?.Messages?.Count > 0;

        public bool Loaded => !(Chat is null);

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        public ChatModel Chat
        {
            get => _chat;
            set => SetProperty(ref _chat, value);
        }

        public ICommand AttachFileCommand { get; private set; }

        public ICommand SendMessageCommand { get; private set; }

        public ChatViewModel(IBluCommonServices commonServices, IBluFilePickerService filePickerService)
            : base(commonServices)
        {
            _filePickerService = filePickerService;
        }

        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            var message = (args.NewItems ?? args.OldItems)[0] as MessageModel;

            if (args.Action is NotifyCollectionChangedAction.Add)
            {
                Publish(new MessageSentEvent(message));
            }
            else if (args.Action is NotifyCollectionChangedAction.Remove)
            {
                Publish(new MessageDeletedEvent(message));
            }

            OnPropertyChanged(string.Empty);
        }

        private void OnChatDeleted(ChatDeletedEvent e)
        {
            if (e.Chat != Chat) return;

            Chat = null;
        }

        private void OnChatLaunching(ChatLaunchingEvent e)
        {
            Chat = e.Chat;
        }

        private async void AttachFile(object parameter)
        {
            StorageFile file = await _filePickerService.OpenFileAsync();

            if (file is null) return;

            // ( 0 _ o )
        }

        private void OnChatChanged()
        {
            OnPropertyChanged(name: string.Empty);
            
            if (Chat is null) return;

            Chat.Messages.CollectionChanged += Messages_CollectionChanged;

            Publish(new ChatLaunchedEvent(Chat));

            if (Chat.UnreadCount > 0)
            {
                Chat.UnreadCount = 0;
            }
        }

        private void OnChatChanging()
        {
            if (Chat is null) return;

            Chat.Messages.CollectionChanged -= Messages_CollectionChanged;
        }

        private void SendMessage(string content)
        {
            if (!CanSendMessage(content)) return;

            Chat.Messages.Add(new MessageModel(content));

            InputText = string.Empty;
        }

        private bool CanSendMessage(string content)
        {
            return Loaded && !content.BluIsWhitespace();
        }

        protected override void ConfigureCommands()
        {
            base.ConfigureCommands();

            AttachFileCommand = new BluCommand(AttachFile, _ => Loaded);

            SendMessageCommand = new BluCommand<string>(SendMessage, CanSendMessage);
        }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<ChatDeletedEvent>(OnChatDeleted);
            Subscribe<ChatLaunchingEvent>(OnChatLaunching);
        }

        protected override void OnPropertyChanged(string name)
        {
            if (name == nameof(Chat))
            {
                OnChatChanged();
            }

            base.OnPropertyChanged(name);
        }

        protected override void OnPropertyChanging(string name)
        {
            if (name == nameof(Chat))
            {
                OnChatChanging();
            }

            base.OnPropertyChanging(name);
        }
    }
}