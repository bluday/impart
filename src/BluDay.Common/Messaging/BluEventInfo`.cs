using BluDay.Common.Events;
using System;
using System.Collections.Generic;

namespace BluDay.Common.Messaging
{
    public sealed class BluEventInfo<TEvent> : IBluEventInfo where TEvent : IBluEvent
    {
        public object Sender { get; }

        public IBluEvent Event { get; }

        public IBluEventTopic Topic { get; }

        public DateTime IssuedAt { get; }
        
        public DateTime FinishedAt { get; }

        public IReadOnlyList<Exception> Exceptions { get; }

        public BluEventInfo(
            object                sender,
            TEvent                e,
            BluEventTopic<TEvent> topic,
            DateTime              issuedAt,
            Exception[]           exceptions)
        {
            BluValidator.NotNull(
                (sender,     nameof(sender)),
                (e,          nameof(e)),
                (topic,      nameof(topic)),
                (exceptions, nameof(exceptions))
            );

            Sender = sender;
            Event  = e;

            Topic = topic;

            Exceptions = exceptions;

            IssuedAt   = issuedAt;
            FinishedAt = DateTime.Now;
        }
    }
}