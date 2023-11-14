using BluDay.Common.Events;
using BluDay.Common.Extensions;
using BluDay.Common.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BluDay.Common.Services
{
    public sealed class BluEventService : IBluEventService
    {
        private readonly Logging.IBluLogger _logger;

        private readonly HashSet<IBluEventTopic> _topics = new HashSet<IBluEventTopic>();

        public int TopicsCount => _topics.Count;

        public BluEventTopicInfo[] TopicInfos => _topics.BluSelect(topic => topic.Info);

        public BluEventService(IBluLoggerService loggerService)
        {
            _logger = loggerService.Create(target: this);

            PreloadTopics(); // Temporarily.
        }

        private BluEventTopic<TEvent> GetTopicByPropertyValue<TEvent>(object value)
            where TEvent : IBluEvent
        {
            object key = value ?? typeof(TEvent);

            return GetTopicByPropertyValue(key) as BluEventTopic<TEvent>;
        }

        private IBluEventTopic GetTopicByPropertyValue(object value)
        {
            return _topics.BluFirst(BluEventTopic.GetPredicateByPropertyValue(value));
        }

        private IBluEventTopic[] GetTopics(object target)
        {
            return _topics.BluWhere(topic => topic.HasSubscriber(target));
        }

        public void PreloadTopics()
        {
            BluReflector
                .GetDerivedConcreteClassTypes<IBluEvent>()
                .BluSelect(BluEventTopic.CreateInstance)
                .BluSelect(_topics.BluAddAndReturn);

            _logger.LogInfo(
                message: "Preloaded topics:",
                content: _topics.BluToPrintableValue()
            );
        }

        public BluEventTopicInfo GetTopicInfoByPropertyValue(object value)
        {
            return GetTopicByPropertyValue(value)?.Info;
        }

        public Task<BluEventInfo<TEvent>> NotifyAsync<TEvent>(object sender, TEvent e)
            where TEvent : IBluEvent
        {
            return NotifyAsync(topicName: null, sender, e);
        }

        public Task<BluEventInfo<TEvent>> NotifyAsync<TEvent>(string topicName, object sender, TEvent e)
            where TEvent : IBluEvent
        {
            return Task.Run(() =>
            {
                BluEventTopic<TEvent> topic = GetTopicByPropertyValue<TEvent>(topicName);

                if (topic is null) return null;

                BluEventInfo<TEvent> eventInfo = topic.Notify(sender, e);

                _logger.LogDebug($"Publication to topic \"{topic.Name}\" complete.");

                return eventInfo;
            });
        }

        public Task<bool> SubscribeAsync<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            return SubscribeAsync(topicName: null, handler);
        }

        public Task<bool> SubscribeAsync<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            return Task.Run(() =>
            {
                BluEventTopic<TEvent> topic = GetTopicByPropertyValue<TEvent>(topicName);

                bool subscribed = !(topic is null) && topic.Subscribe(handler);

                _logger.LogDebug(
                    "{0} -> \"{1}\" ({2}<{3}>)",
                    subscribed ? "New subscription" : "Subscription failure",
                    topic.Name,
                    handler.Target,
                    handler.Target.GetHashCode()
                );

                return subscribed;
            });
        }

        public Task<bool> UnsubscribeAsync<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            return UnsubscribeAsync(topicName: null, handler);
        }

        public Task<bool> UnsubscribeAsync<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent
        {
            return Task.Run(() =>
            {
                BluEventTopic<TEvent> topic = GetTopicByPropertyValue<TEvent>(topicName);

                bool unsubscribed = !(topic is null) && topic.Unsubscribe(handler);

                _logger.LogDebug(
                    "{0} -> \"{1}\" ({2}<{3}>)",
                    unsubscribed ? "Unsubscribed" : "Unsubscription failure",
                    topic.Name,
                    handler.Target,
                    handler.Target.GetHashCode()
                );

                return unsubscribed;
            });
        }

        public Task<BluEventTopicInfo[]> UnsubscribeAsync(object target)
        {
            return Task.Run(() =>
            {
                var topics = new List<BluEventTopicInfo>();

                foreach (IBluEventTopic topic in GetTopics(target))
                {
                    if (!topic.Unsubscribe(target))
                    {
                        continue;
                    }

                    topics.Add(topic.Info);
                }

                return topics.ToArray();
            });
        }
    }
}