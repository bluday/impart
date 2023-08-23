using System;

namespace BluDay.Common.Messaging
{
    public interface IBluEventInfo
    {
        object Sender { get; }

        Events.IBluEvent Event { get; }

        IBluEventTopic Topic { get; }

        DateTime IssuedAt { get; }
        
        DateTime FinishedAt { get; }

        System.Collections.Generic.IReadOnlyList<Exception> Exceptions { get; }
    }
}