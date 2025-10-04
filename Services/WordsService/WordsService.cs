using WorkerTest.Models;
using WorkerTest.Repositories.ChatRepository;

namespace WorkerTest.Services.WordsService
{
    public class WordsService(IWordsRepository wordsRepository) : IWordsService
    {
        public readonly IWordsRepository _wordsRepository = wordsRepository;
        public async Task<IEnumerable<Words>> GetWordsAsync()
        {
            return await _wordsRepository.GetWordsAsync();
        }
    }
}