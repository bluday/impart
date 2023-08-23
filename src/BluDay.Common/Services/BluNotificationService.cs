using System.Threading.Tasks;

namespace BluDay.Common.Services
{
    public sealed class BluNotificationService : Service, IBluNotificationService
    {
        public int DefaultDuration { get; set; } = BluConstants.DEFAULT_NOTIFICATION_DURATION;

        public BluNotificationService(IBluCommonServices commonServices) : base(commonServices) { }

        public Task<bool> SendAsync(string title, string message)
        {
            return SendAsync(title, message, DefaultDuration);
        }

        public async Task<bool> SendAsync(string title, string message, int duration)
        {
            return await Task.Run(() => false);
        }
    }
}