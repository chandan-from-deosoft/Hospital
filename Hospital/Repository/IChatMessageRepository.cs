using TestBot.Model;

namespace TestBot.Repository
{
    public interface IChatMessageRepository
    {
        Task<ChatMessage> GetGreetingMessageAsync();
        Task<ChatMessage> GetChatMessageAsync(int id);
    }
}
