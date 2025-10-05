using WorkerTest.Models;

namespace WorkerTest.Repositories.ChatRepository
{
    public interface IWordsRepository
    {
        Task<List<Words>> GetWordsAsync();
    }
}