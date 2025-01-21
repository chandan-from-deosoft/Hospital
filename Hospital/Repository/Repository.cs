using System.Data;
using Dapper;
using Hospital.Models;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for SQL Server


namespace Hospital.Repository
{
    public class Repository : IRepository<ChatMessage>, IRepository<ChatButton>
    {
        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ChatMessage>> GetAllAsync()
        {
            return await _dbConnection.QueryAsync<ChatMessage>("SELECT * FROM chat_messages");
        }

        public async Task<ChatMessage> GetByIdAsync(int id)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<ChatMessage>("SELECT * FROM chat_messages WHERE id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<ChatButton>> GetOptionsByChatIdAsync(int chatId)
        {
            return await _dbConnection.QueryAsync<ChatButton>("SELECT * FROM chat_buttons WHERE chat_data_id = @ChatId", new { ChatId = chatId });
        }
    }
}
