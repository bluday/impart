namespace BluDay.Impart.Events
{
    public sealed class MessageEditedEvent : Common.Events.IBluEvent
    {
        public Models.MessageModel Message { get; }

        public MessageEditedEvent(Models.MessageModel message)
        {
            Message = message;
        }
    }
}