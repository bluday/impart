using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.System;

namespace BluDay.Common
{
    public static class BluTaskHelper
    {
        public static DispatcherQueue DispatcherQueue { get; }

        public static DispatcherQueuePriority DefaultPriority { get; set; }

        static BluTaskHelper()
        {
            DispatcherQueue = CoreApplication.MainView.DispatcherQueue;

            DefaultPriority = DispatcherQueuePriority.High;
        }

        public static Task EnqueueDelegate(Action function)
        {
            var task = new Task(function);

            DispatcherQueue.TryEnqueue(async () => await task);

            return task;
        }

        public static Task<TResult> EnqueueDelegate<TResult>(Func<TResult> function)
        {
            var completionSource = new TaskCompletionSource<TResult>();

            DispatcherQueue.TryEnqueue(() =>
            {
                try
                {
                    completionSource.SetResult(function());
                }
                catch (Exception ex)
                {
                    completionSource.SetException(ex);
                }
            });

            return completionSource.Task;
        }
    }
}