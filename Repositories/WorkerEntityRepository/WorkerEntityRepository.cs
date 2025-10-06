using Dapper;
using WorkerTest.Factory;
using WorkerTest.Models;
using WorkerTest.Scripts;

namespace WorkerTest.Repositories.WorkerEntityRepository
{
    public class WorkerEntityRepository(IDbConnectionFactory connectionFactory) : IWorkerEntityRepository
    {
        public readonly IDbConnectionFactory _connectionFactory = connectionFactory;

        public async Task<WorkerEntity> CreateNewWorkerAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            var sql = WorkerEntityScritps.InsertNewWorkerEntity;
            var worker = await connection.QuerySingleAsync<WorkerEntity>(sql);
            return worker;
        }

        public async Task<bool> UpdateWorkerAsync(WorkerEntity worker)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();
                var sql = WorkerEntityScritps.UpdateWorkerEntity;
                await connection.QuerySingleAsync<WorkerEntity>(sql, new
                {
                    worker.MessageId,
                    DeathDate = DateTime.UtcNow,
                    WorkerId = worker.Id
                });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}