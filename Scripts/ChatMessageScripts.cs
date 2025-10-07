namespace WorkerTest.Scripts
{
    public static class ChatMessageScripts
    {
        public const string SelectAllMessages = @"
            SELECT id AS Id, message AS Message, prev_message AS PrevMesage, next_message AS NextMesage
            FROM workers_chat.chat_message        
        ";

        public const string InsertChatMessage = @"
            INSERT INTO workers_chat.chat_message(message, prev_message)
            VALUES (@Message, @PrevMessage)
            RETURNING *;
        ";

        public const string SelectLastMessage = @"
            SELECT cm.*
            FROM workers_chat.chat_message cm
            LEFT JOIN workers_chat.chat_message next ON cm.id = next.prev_message
            WHERE next.id IS NULL;
        ";

    }
}