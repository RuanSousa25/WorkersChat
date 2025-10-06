namespace WorkerTest.Scripts
{
    public static class WorkerEntityScritps
    {
        public const string InsertNewWorkerEntity = @"
            INSERT INTO workers_chat.worker_entity DEFAULT VALUES
            RETURNING *, born_date AS BornDate, death_date AS DeathDate;
        ";

        public const string UpdateWorkerEntity = @"
            UPDATE workers_chat.worker_entity
            SET message_id = @MessageId, death_date = @DeathDate
            WHERE id = @WorkerId;    
        ";
    }
}