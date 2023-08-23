namespace BluDay.Impart.Events
{
    public sealed class ChatArchivedEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatArchivedEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}