namespace BluDay.Impart.Events
{
    public sealed class CurrentUserUpdatedEvent : Common.Events.IBluEvent
    {
        public Models.UserModel User { get; }

        public CurrentUserUpdatedEvent(Models.UserModel user)
        {
            User = user;
        }
    }
}