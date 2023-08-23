namespace BluDay.Common.Events
{
    public sealed class ViewResolutionRequestEvent : IBluEvent
    {
        public int ParentInclusionLevel { get; }

        public System.Type ViewType { get; }

        public ViewResolutionRequestEvent(System.Type viewType, int parentInclusionLevel)
        {
            BluValidator.ValidateViewType(viewType);

            ViewType = viewType;

            ParentInclusionLevel = parentInclusionLevel;
        }
    }
}