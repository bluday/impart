namespace BluDay.Common.Events
{
    public sealed class NavigationRequestEvent : IBluEvent
    {
        public object ViewPropertyValue { get; }

        public NavigationRequestEvent(object viewPropertyValue)
        {
            BluValidator.NotNull(viewPropertyValue, nameof(viewPropertyValue));

            ViewPropertyValue = viewPropertyValue;
        }
    }
}