using WorkerTest.Models;

namespace WorkerTest.Services.ChatService
{
    public interface IChatService
    {
        Task<List<ChatMessage>> GetAllChatMessagesAsync();
        Task<ChatMessage?> GetChatMessageByIdAsync(int id);
        Task<ChatMessage> CreateChatMessageAsync(ChatMessage newMessage);

    }
}