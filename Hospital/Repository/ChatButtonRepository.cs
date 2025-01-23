using System.Data;
using System.Text.Json;
using Dapper;
using TestBot.Model;

namespace TestBot.Repository
{
    public class ChatButtonRepository : IChatButtonRepository
    {
        private readonly IDbConnection _dbConnection;

        public ChatButtonRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ChatButtons>> GetChatButtonAsync(int chatDataId)
        {
            // Query to fetch all rows where chat_data_id matches the provided ID
            var query = "SELECT [Id], [chat_data_id] AS ChatDataId, [text] AS Text, [next] AS Next FROM [Hospital].[dbo].[chat_btn] WHERE chat_data_id = @ChatDataId";
            var result = await _dbConnection.QueryAsync<ChatButtons>(query, new { ChatDataId = chatDataId });

            // Return the result directly
            return result;
        }
    }
}
