using WorkerTest.Models;

namespace WorkerTest.Services.WordsService
{
    public interface IWordsService
    {
        Task<List<Words>> GetWordsAsync();
        Task<Words> GetRandomPronomeAsync();
        Task<Words> GetRandomVerboByPronomeAsync(Words pronome);
        Task<Words> GetRandomObjetoAsync();
        Task<Words> GetRandomPredicativoAsync(Words pronome, Words verbo);
    }
}