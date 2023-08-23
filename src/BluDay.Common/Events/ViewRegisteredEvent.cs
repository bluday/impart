using BluDay.Common.ViewManagement;

namespace BluDay.Common.Events
{
    public sealed class ViewRegisteredEvent : IBluEvent
    {
        public BluViewInfo View { get; }

        public ViewRegisteredEvent(BluViewInfo view)
        {
            BluValidator.NotNull(view, nameof(view));

            View = view;
        }
    }
}