using WorkerTest.Models;
using WorkerTest.Repositories.ChatRepository;
using WorkerTest.Repositories.WordsRepository;

namespace WorkerTest.Services.WordsService
{
    public class WordsService(IWordsRepository wordsRepository) : IWordsService
    {
        public readonly IWordsRepository _wordsRepository = wordsRepository;
        public async Task<List<Words>> GetWordsAsync()
        {
            return await _wordsRepository.GetWordsAsync();
        }
    }
}