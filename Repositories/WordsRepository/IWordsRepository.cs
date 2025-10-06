using WorkerTest.Models;

namespace WorkerTest.Repositories.WordsRepository
{
    public interface IWordsRepository
    {
        Task<List<Words>> GetWordsAsync();
    }
}