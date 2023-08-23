namespace BluDay.Impart.Events
{
    public sealed class ChatDeletedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatDeletedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}