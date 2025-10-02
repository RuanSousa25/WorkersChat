using WorkerTest.Models;

namespace WorkerTest.Repositories.ChatRepository
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetChatMessagesAsync();
    }
}