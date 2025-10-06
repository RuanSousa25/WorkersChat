using WorkerTest.Models;

namespace WorkerTest.Services.WorkerEntityService
{
    public interface IWorkerEntityService
    {
        Task<WorkerEntity> CreateNewWorkerAsync();
        Task<bool> UpdateWorkerAsync(WorkerEntity worker);
    }
}