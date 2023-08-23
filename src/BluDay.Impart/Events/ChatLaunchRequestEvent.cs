namespace BluDay.Impart.Events
{
    public sealed class ChatLaunchRequestEvent : Common.Events.IBluEvent
    {
        public Models.ChatModel Chat { get; }

        public ChatLaunchRequestEvent(Models.ChatModel chat)
        {
            Chat = chat;
        }
    }
}