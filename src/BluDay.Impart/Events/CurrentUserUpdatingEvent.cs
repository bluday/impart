namespace BluDay.Impart.Events
{
    public sealed class CurrentUserUpdatingEvent : Common.Events.IBluEvent
    {
        public Models.UserModel User { get; }

        public CurrentUserUpdatingEvent(Models.UserModel user)
        {
            User = user;
        }
    }
}