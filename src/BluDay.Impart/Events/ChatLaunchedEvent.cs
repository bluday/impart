namespace BluDay.Impart.Events
{
    public sealed class ChatLaunchedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatLaunchedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}