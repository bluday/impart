namespace BluDay.Impart.Events
{
    public sealed class ChatCreatedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatCreatedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}