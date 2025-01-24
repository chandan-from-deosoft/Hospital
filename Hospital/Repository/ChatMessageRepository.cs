using System.Data;
using Dapper;
using TestBot.Model;


namespace TestBot.Repository
{
    public class ChatMessageRepository: IChatMessageRepository
    {
        private readonly IDbConnection _dbConnection;

        public ChatMessageRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ChatMessage> GetGreetingMessageAsync()
        {
            var query = "SELECT [name],[message],[expected_input_type] FROM [Hospital].[dbo].[chat_msg] WHERE id = 1";
            return await _dbConnection.QueryFirstOrDefaultAsync<ChatMessage>(query);
        }

        public async Task<ChatMessage> GetChatData(int chatId)
        {
            var query = "SELECT [name],[message],[expected_input_type] FROM [Hospital].[dbo].[chat_msg] WHERE id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<ChatMessage>(query, new { Id = chatId });
        }


    }
}
