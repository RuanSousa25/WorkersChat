namespace WorkerTest.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; } = "";
        public int? PrevMessage { get; set; }
        public int? NextMessage { get; set; }
    }
}