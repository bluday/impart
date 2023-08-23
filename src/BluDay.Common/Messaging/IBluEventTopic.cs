namespace BluDay.Common.Messaging
{
    public interface IBluEventTopic
    {
        bool Enabled { get; set; }

        int SubscribersCount { get; }

        string Name { get; }

        System.Guid Id { get; }

        System.Type EventType { get; }

        BluEventTopicInfo Info { get; }

        bool HasSubscriber(object target);

        bool Unsubscribe(object target);
    }
}