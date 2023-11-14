using BluDay.Common.Events;
using BluDay.Common.Messaging;
using System.Threading.Tasks;

namespace BluDay.Common.Services
{
    public interface IBluEventService
    {
        int TopicsCount { get; }

        BluEventTopicInfo[] TopicInfos { get; }

        BluEventTopicInfo GetTopicInfoByPropertyValue(object value);

        Task<BluEventInfo<TEvent>> NotifyAsync<TEvent>(object sender, TEvent e)
            where TEvent : IBluEvent;

        Task<BluEventInfo<TEvent>> NotifyAsync<TEvent>(string topicName, object sender, TEvent e)
            where TEvent : IBluEvent;

        Task<bool> SubscribeAsync<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent;

        Task<bool> SubscribeAsync<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent;

        Task<bool> UnsubscribeAsync<TEvent>(BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent;

        Task<bool> UnsubscribeAsync<TEvent>(string topicName, BluEventHandler<TEvent> handler)
            where TEvent : IBluEvent;

        Task<BluEventTopicInfo[]> UnsubscribeAsync(object target);
    }
}