namespace BluDay.Common.Messaging
{
    public sealed class BluEventTopicInfo
    {
        private readonly IBluEventTopic _topic;

        public bool Enabled => _topic.Enabled;

        public string Name => _topic.Name;

        public System.Guid Id => _topic.Id;

        public System.Type EventType => _topic.EventType;

        public int SubscribersCount => _topic.SubscribersCount;

        public BluEventTopicInfo(IBluEventTopic topic)
        {
            BluValidator.NotNull(topic, nameof(topic));

            _topic = topic;
        }

        public override string ToString() => _topic.ToString();
    }
}