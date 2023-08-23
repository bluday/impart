using BluDay.Common.Extensions;
using BluDay.Common.Services;
using BluDay.Impart.Events;
using BluDay.Impart.Models;
using System;
using System.Collections.Generic;

namespace BluDay.Impart.Services
{
    public class ImpartChatService : Service, IImpartChatService
    {
        private ChatModel _currentChat;

        public IReadOnlyList<ChatModel> Chats { get; private set; }

        public ChatModel CurrentChat
        {
            get => _currentChat;
            set
            {
                if (!(value is null) && !Chats.BluContains(value))
                {
                    throw new ArgumentException("Chat does not exist.");
                }

                Publish(new ChatLaunchingEvent(value));

                _currentChat = value;

                Publish(new ChatLaunchedEvent(value));
            }
        }

        public ImpartChatService(IBluCommonServices commonServices) : base(commonServices) { }

        private void OnChatLaunchRequest(ChatLaunchRequestEvent e)
        {
            CurrentChat = e.Chat;
        }

        private void OnSampleUserLoaded(SampleUserLoadedEvent e)
        {
            Chats = e.User.Chats;

            CurrentChat = null;
        }

        protected override void ConfigureSubscriptions()
        {
            Subscribe<SampleUserLoadedEvent>(OnSampleUserLoaded);
            Subscribe<ChatLaunchRequestEvent>(OnChatLaunchRequest);
        }
    }
}