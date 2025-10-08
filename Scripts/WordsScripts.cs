namespace WorkerTest.Scripts
{
    public static class WordsScripts
    {
        public const string SelectAllWords = @"
            SELECT id AS Id, word AS Word, word_type_id AS WordType, conjugation_group_id AS ConjugationGroup
            FROM workers_chat.words        
        ";
    }
}