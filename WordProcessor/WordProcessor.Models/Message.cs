using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordProcessor.Models
{
    [Table("Message")]
    public partial class Message
    {
        public long Id { get; set; }

        [Required]
        public string Input { get; set; }

        public long Characters { get; set; }

        public int Words { get; set; }

        public int Sentences { get; set; }

        public int Paragraphs { get; set; }
    }
}
