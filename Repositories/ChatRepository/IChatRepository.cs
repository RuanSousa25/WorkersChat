using WorkerTest.Models;

namespace WorkerTest.Repositories.ChatRepository
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetChatMessagesAsync();
        Task<ChatMessage?> GetLastMessageAsync();
        Task<ChatMessage> InsertMessageAsync(ChatMessage message);
           
    }
}