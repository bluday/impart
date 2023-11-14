using BluDay.Common.Extensions;
using BluDay.Common.Services;
using BluDay.Impart.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BluDay.Impart.Services
{
    public sealed class ImpartSampleDataService : BluService, IImpartSampleDataService
    {
        public int CurrentUserIndex { get; } = -1;

        public UserModel CurrentUser { get; private set; }

        public static JsonSerializerOptions JsonOptions { get; }

        static ImpartSampleDataService()
        {
            JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public ImpartSampleDataService(IImpartConfig config, IBluCommonServices commonServices)
            : base(commonServices)
        {
            CurrentUserIndex = config.SampleDataUserIndex;

            if (CurrentUserIndex >= 0)
            {
                LoadAsync(CurrentUserIndex).ConfigureAwait(false);
            }
        }

        private async Task<SampleDataContext> RetrieveSampleDataAsync()
        {
            string json = await Common.IO.File.ReadFromAssemblyAsync("db.json");

            return JsonSerializer.Deserialize<SampleDataContext>(json, JsonOptions);
        }

        public async Task<bool> LoadAsync(int userIndex)
        {
            var context = await RetrieveSampleDataAsync();

            if (context.Users.Length == 0 || userIndex > context.Users.Length)
            {
                Logger.LogDebug($"User index is out of bounds.");

                return false;
            }

            CurrentUser = context.Users[userIndex];

            foreach (Guid chatId in CurrentUser.ChatIds)
            {
                var chat = context.Chats.BluFirst(entry => entry.Id == chatId);

                if (chat is null) continue;

                CurrentUser.Chats.BluTryAdd(chat);

                foreach (MessageModel message in context.Messages)
                {
                    if (message.ChatId != chat.Id)
                    {
                        continue;
                    }

                    UserModel sender = context
                        .Users
                        .BluFirst(user => user.Id == message.UserId);

                    if (sender is null) continue;

                    chat.Members.BluTryAdd(sender);

                    chat.Messages.BluTryAdd(message);

                    if (message.UserId != CurrentUser.Id)
                    {
                        continue;
                    }
                        
                    if (!message.Read) chat.UnreadCount++;

                    message.Side = HorizontalAlignment.Right;
                }
            }

            Notify(new Events.SampleUserLoadedEvent(CurrentUser));

            Logger.LogDebug($"Sample data loaded for user index {userIndex}.");

            return true;
        }

        private class SampleDataContext
        {
            public ChatModel[] Chats { get; set; }

            public UserModel[] Users { get; set; }

            public MessageModel[] Messages { get; set; }
        }
    }
}