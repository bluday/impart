namespace BluDay.Impart.Events
{
    public sealed class ChatClearedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatClearedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}