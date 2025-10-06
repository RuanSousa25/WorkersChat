using WorkerTest.Models;
using WorkerTest.Repositories.WorkerEntityRepository;

namespace WorkerTest.Services.WorkerEntityService
{
    public class WorkerEntityService(IWorkerEntityRepository workerEntityRepository) : IWorkerEntityService
    {
        public readonly IWorkerEntityRepository _workerEntityRepository = workerEntityRepository;
        public async Task<WorkerEntity> CreateNewWorkerAsync()
        {
            return await _workerEntityRepository.CreateNewWorkerAsync();
        }
        public async Task<bool> UpdateWorkerAsync(WorkerEntity worker)
        {
            return await _workerEntityRepository.UpdateWorkerAsync(worker);
        }
    }
}