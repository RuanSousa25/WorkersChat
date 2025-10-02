using WorkerTest.Models;

namespace WorkerTest.Services.ChatService
{
    public class ChatService : IChatService
    {

        public async Task<List<ChatMessage>> GetAllChatMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMessage?> GetChatMessageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMessage> CreateChatMessageAsync(ChatMessage newMessage)
        {
            throw new NotImplementedException();
        }
    }
}