namespace WorkerTest.Scripts
{
    public static class WordsScripts
    {
        public const string SelectAllWords = @"
            SELECT id AS Id, 
            word AS Word,
             word_type_id AS WordType,
              person_group_id AS PersonGroup,
              number_group_id AS NumberGroup,
               gender_group_id AS GenderGroup,
                transitivity_group_id AS TransitivityGroup,
                 predicative_group_id AS PredicativeGroup
            FROM workers_chat.words        
        ";
    }
}