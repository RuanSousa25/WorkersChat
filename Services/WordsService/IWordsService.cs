using WorkerTest.Models;

namespace WorkerTest.Services.WordsService
{
    public interface IWordsService
    {
        Task<List<Words>> GetWordsAsync();
    }
}