using WorkerTest.Models.Enums;

namespace WorkerTest.Models
{
    public class Words
    {
        public int Id { get; set; }
        public string Word { get; set; } = "";
        public WordTypes WordType { get; set; }

    }
}