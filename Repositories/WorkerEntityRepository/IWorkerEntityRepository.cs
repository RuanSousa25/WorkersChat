using WorkerTest.Models;

namespace WorkerTest.Repositories.WorkerEntityRepository
{
    public interface IWorkerEntityRepository
    {
        Task<WorkerEntity> CreateNewWorkerAsync();
        Task<bool> UpdateWorkerAsync(WorkerEntity worker); 
    }
}