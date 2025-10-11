using WorkerTest.Models;
using WorkerTest.Models.Enums;
using WorkerTest.Repositories.ChatRepository;
using WorkerTest.Services.WordsService;

namespace WorkerTest.Services.ChatService
{
    public class ChatService(IChatRepository chatRepository, IWordsService wordsService) : IChatService
    {
        public IChatRepository _chatRepository = chatRepository;
        public IWordsService _wordsServices = wordsService;

        public async Task<List<ChatMessage>> GetAllChatMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMessage?> GetChatMessageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMessage> GenerateMessageAsync()
        {
            Random rand = new();
            var message = "";

            var words = await _wordsServices.GetWordsAsync();

            var pronomes = words.Where(w => w.WordType == WordTypes.Pronome).ToList();
            var pronome = pronomes[rand.Next(pronomes.Count)];
            message += pronome.Word;


            var verbos = words.Where(w => w.WordType == WordTypes.Verbo && w.ConjugationGroup == pronome.ConjugationGroup).ToList();
            var verbo = verbos[rand.Next(verbos.Count)];
            message += " " + verbo.Word;

            if (verbo.TransitivityGroup != TransitivityGroup.Intransitivo)
            {
                var substantivos = words.Where(w => w.WordType == WordTypes.Substantivo && w.PredicativeGroup == 0).ToList();
                var substantivo = substantivos[rand.Next(substantivos.Count)];
                message += " " + substantivo.Word;
            }
            else
            {
                var predicativos = words.Where(w =>
                w.WordType == WordTypes.Substantivo &&
                 w.PredicativeGroup == verbo.PredicativeGroup &&
                 (pronome.GenderGroup == GenderGroup.NaoIdentificado || pronome.GenderGroup == w.GenderGroup)).ToList();
                var predicativo = predicativos[rand.Next(predicativos.Count)];
                message += " " + predicativo.Word;
            }

            var lastMessage = _chatRepository.GetLastMessageAsync();

            var newMessage = new ChatMessage
            {
                Message = message,
                PrevMessage = lastMessage?.Id
            };
            return await _chatRepository.InsertMessageAsync(newMessage);
        }
    }
}