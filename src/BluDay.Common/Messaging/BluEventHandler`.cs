namespace BluDay.Common.Messaging
{
    public delegate void BluEventHandler<TEvent>(TEvent e) where TEvent : Events.IBluEvent;
}