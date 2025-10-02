using WorkerTest.Models;

namespace WorkerTest.Repositories.ChatRepository
{
    public interface IWordsRepository
    {
        Task<IEnumerable<ChatMessage>> GetWordsAsync();
    }
}