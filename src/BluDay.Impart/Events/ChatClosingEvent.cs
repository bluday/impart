namespace BluDay.Impart.Events
{
    public sealed class ChatClosingEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatClosingEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}