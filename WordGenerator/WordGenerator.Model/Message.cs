namespace WordGenerator.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Input { get; set; }
        public long Characters { get; set; }
        public int Words { get; set; }
        public int Sentences { get; set; }
        public int Paragraphs { get; set; }
    }
}
