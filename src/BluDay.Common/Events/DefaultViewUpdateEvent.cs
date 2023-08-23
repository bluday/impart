using BluDay.Common.ViewManagement;

namespace BluDay.Common.Events
{
    public sealed class DefaultViewUpdateEvent : IBluEvent
    {
        public BluViewInfo View { get; }

        public DefaultViewUpdateEvent(BluViewInfo view)
        {
            BluValidator.NotNull(view, nameof(view));

            View = view;
        }
    }
}