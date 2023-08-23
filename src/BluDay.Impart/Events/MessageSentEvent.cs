namespace BluDay.Impart.Events
{
    public sealed class MessageSentEvent : Common.Events.IBluEvent
    {
        public Models.MessageModel Message { get; }

        public MessageSentEvent(Models.MessageModel message)
        {
            Message = message;
        }
    }
}