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

            var words = await _wordsServices.GetWordsAsync();

            var pronomes = words.Where(w => w.WordType == WordTypes.Pronome).ToList();
            var pronome = pronomes[rand.Next(pronomes.Count)];


            var verbos = words.Where(w => w.WordType == WordTypes.Verbo).ToList();
            var verbo = verbos[rand.Next(verbos.Count)];

            var substantivos = words.Where(w => w.WordType == WordTypes.Substantivo).ToList();
            var substantivo = substantivos[rand.Next(substantivos.Count)];

            var lastMessage = _chatRepository.GetLastMessageAsync();

            var newMessage = new ChatMessage
            {
                Message = $"{pronome.Word} {verbo.Word} {substantivo.Word}",
                PrevMessage = lastMessage?.Id
            };
            return await _chatRepository.InsertMessageAsync(newMessage);
        }
    }
}