using Dapper;
using WorkerTest.Factory;
using WorkerTest.Models;
using WorkerTest.Scripts;

namespace WorkerTest.Repositories.ChatRepository
{
    public class WordsRepository(IDbConnectionFactory connectionFactory) : IWordsRepository
    {
        public readonly IDbConnectionFactory _connectionFactory = connectionFactory;
        public async Task<IEnumerable<ChatMessage>> GetWordsAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = WordsScripts.SelectAllWords;
            return await connection.QueryAsync<ChatMessage>(sql);
        }
    }
}