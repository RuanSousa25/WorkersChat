namespace WorkerTest.Scripts
{
    public static class WordsScripts
    {
        public const string SelectAllWords = @"
            SELECT id AS Id, word AS Word, word_type_id AS WordType, conjugation_group_id AS ConjugationGroup, gender_group_id AS GenderGroup, transitivity_group_id AS TransitivityGroup
            FROM workers_chat.words        
        ";
    }
}