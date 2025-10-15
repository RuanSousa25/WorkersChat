using WorkerTest.Models;
using WorkerTest.Models.Enums;
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

        public async Task<Words> GetRandomPronomeAsync()
        {
            List<Words> words = await _wordsRepository.GetWordsAsync();
            Random rand = new();
            var pronomes = words.Where(w => w.WordType == WordTypes.Pronome).ToList();
            var pronome = pronomes[rand.Next(pronomes.Count)];
            return pronome;
        }

        public async Task<Words> GetRandomVerboByPronomeAsync(Words pronome)
        {
            List<Words> words = await _wordsRepository.GetWordsAsync();
            Random rand = new();
            var verbos = words.Where(w => w.WordType == WordTypes.Verbo && w.PersonGroup == pronome.PersonGroup && w.NumberGroup == pronome.NumberGroup).ToList();
            var verbo = verbos[rand.Next(verbos.Count)];
            return verbo;
        }

        public async Task<Words> GetRandomObjetoAsync()
        {
            List<Words> words = await _wordsRepository.GetWordsAsync();
            Random rand = new();
            var substantivos = words.Where(w => w.WordType == WordTypes.Substantivo && w.PredicativeGroup == 0).ToList();
            var substantivo = substantivos[rand.Next(substantivos.Count)];
            return substantivo;
        }

        public async Task<Words> GetRandomPredicativoAsync(Words pronome, Words verbo)
        {
            List<Words> words = await _wordsRepository.GetWordsAsync();
            Random rand = new();
            var predicativos = words.Where(w =>
            w.WordType == WordTypes.Substantivo &&
            w.PredicativeGroup == verbo.PredicativeGroup &&
            w.NumberGroup == pronome.NumberGroup &&
            (pronome.GenderGroup == GenderGroup.NaoIdentificado || pronome.GenderGroup == w.GenderGroup)
            ).ToList();
            return predicativos[rand.Next(predicativos.Count)];
        }
    }
}