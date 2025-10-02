using Dapper;
using WorkerTest.Factory;
using WorkerTest.Models;
using WorkerTest.Scripts;

namespace WorkerTest.Repositories.ChatRepository
{
    public class ChatRepository(IDbConnectionFactory connectionFactory) : IChatRepository
    {
        public readonly IDbConnectionFactory _connectionFactory = connectionFactory;
        public async Task<IEnumerable<ChatMessage>> GetChatMessagesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = ChatMessageScripts.SelectAllMessages;
            return await connection.QueryAsync<ChatMessage>(sql);
        }
    }
}