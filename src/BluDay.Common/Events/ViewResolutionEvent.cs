using BluDay.Common.Extensions;

namespace BluDay.Common.Events
{
    public sealed class ViewResolutionEvent : IBluEvent
    {
        public UI.IBluView EndView { get; }

        public System.Collections.Generic.IReadOnlyList<UI.IBluView> Views { get; }

        public ViewResolutionEvent(UI.IBluView[] views)
        {
            BluValidator.NotNull(views, nameof(views));

            Views = views;

            EndView = views.BluLast();
        }
    }
}