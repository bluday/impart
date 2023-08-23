namespace BluDay.Impart.Events
{
    public sealed class ChatClosedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatClosedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}