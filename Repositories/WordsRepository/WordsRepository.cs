using Dapper;
using WorkerTest.Factory;
using WorkerTest.Models;
using WorkerTest.Scripts;

namespace WorkerTest.Repositories.WordsRepository
{
    public class WordsRepository(IDbConnectionFactory connectionFactory) : IWordsRepository
    {
        public readonly IDbConnectionFactory _connectionFactory = connectionFactory;
        public async Task<List<Words>> GetWordsAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = WordsScripts.SelectAllWords;
            var result = await connection.QueryAsync<Words>(sql);
            return [.. result];
        }
    }
}