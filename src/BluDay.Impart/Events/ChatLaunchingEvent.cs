namespace BluDay.Impart.Events
{
    public sealed class ChatLaunchingEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatLaunchingEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}