namespace BluDay.Impart.Services
{
    public interface IImpartChatService
    {
        Models.ChatModel CurrentChat { get; }

        System.Collections.Generic.IReadOnlyList<Models.ChatModel> Chats { get; }
    }
}