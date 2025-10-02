namespace WorkerTest.Scripts
{
    public static class ChatMessageScripts
    {
        public const string SelectAllMessages = @"
            SELECT id AS Id, message AS Message, prev_message AS PrevMesage, next_message AS NextMesage
            FROM workers_chat.chat_message        
        ";
    }
}