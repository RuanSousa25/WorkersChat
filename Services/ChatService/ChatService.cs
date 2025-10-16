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
            var outroPeriodo = false;


            do
            {
                var pronome = await _wordsServices.GetRandomPronomeAsync();
                var verbo = await _wordsServices.GetRandomVerboByPronomeAsync(pronome);

                message += pronome.Word;
                message += " " + verbo.Word;

                if (verbo.TransitivityGroup != TransitivityGroup.Intransitivo)
                {
                    var objeto = await _wordsServices.GetRandomObjetoAsync();
                    message += " " + objeto.Word;
                }
                else if (verbo.PredicativeGroup != PredicativeGroup.Nenhum)
                {
                    Words predicativo = await _wordsServices.GetRandomPredicativoAsync(pronome, verbo);
                    message += " " + predicativo.Word;
                }


                outroPeriodo = rand.Next(4) == 1;
                message += outroPeriodo ? ". " : ".";
            } while (outroPeriodo);

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