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

        public async Task<ChatMessage?> GetLastMessageAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = ChatMessageScripts.SelectLastMessage;
            return await connection.QuerySingleAsync<ChatMessage?>(sql);
        }
        public async Task<ChatMessage> InsertMessageAsync(ChatMessage message)
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = ChatMessageScripts.InsertChatMessage;
            return await connection.QuerySingleAsync<ChatMessage>(sql, message);
        }
    }
}