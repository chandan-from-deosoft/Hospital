using TestBot.Model;

namespace TestBot.Repository
{
    public interface IChatButtonRepository
    {
        Task<IEnumerable<ChatButtons>> GetChatButtonAsync(int chatDataId);
    }
}
