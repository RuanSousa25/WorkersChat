using WorkerTest.Models.Enums;

namespace WorkerTest.Models
{
    public class Words
    {
        public int Id { get; set; }
        public string Word { get; set; } = "";
        public WordTypes WordType { get; set; }
        public ConjugationGroup ConjugationGroup { get; set; }
        public GenderGroup GenderGroup { get; set; }
        public TransitivityGroup TransitivityGroup { get; set; }
        public PredicativeGroup PredicativeGroup { get; set; }

    }
}