using System.Threading.Tasks;

namespace BluDay.Common.Services
{
    public interface IBluNotificationService
    {
        int DefaultDuration { get; set; }

        Task<bool> SendAsync(string title, string message);

        Task<bool> SendAsync(string title, string message, int duration);
    }
}