namespace BluDay.Impart.Events
{
    public sealed class SampleUserLoadedEvent : Common.Events.IBluEvent
    {
        public Models.UserModel User { get; }

        public SampleUserLoadedEvent(Models.UserModel user)
        {
            Common.BluValidator.NotNull(user, nameof(user));

            User = user;
        }
    }
}