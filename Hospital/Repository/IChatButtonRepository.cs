using TestBot.Model;

namespace TestBot.Repository
{
    public interface IChatButtonRepository
    {
        Task<IEnumerable<ChatButtons>> GetOptionsData(int chatDataId);
    }
}
