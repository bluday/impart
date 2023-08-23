namespace BluDay.Impart.Events
{
    public sealed class MessageDeletedEvent : Common.Events.IBluEvent
    {
        public Models.MessageModel Message { get; }

        public MessageDeletedEvent(Models.MessageModel message)
        {
            Message = message;
        }
    }
}