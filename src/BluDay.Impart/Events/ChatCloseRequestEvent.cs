namespace BluDay.Impart.Events
{
    public sealed class ChatCloseRequestEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatCloseRequestEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}