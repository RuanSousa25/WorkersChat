using WorkerTest.Models.Enums;

namespace WorkerTest.Models
{
    public class Words
    {
        public int Id { get; set; }
        public string Word { get; set; } = "";
        public bool ArtigoDefinido { get; set; }
        public WordTypes WordType { get; set; }
        public PersonGroup PersonGroup { get; set; }
        public NumberGroup NumberGroup { get; set; }
        public GenderGroup GenderGroup { get; set; }
        public TransitivityGroup TransitivityGroup { get; set; }
        public PredicativeGroup PredicativeGroup { get; set; }

    }
}