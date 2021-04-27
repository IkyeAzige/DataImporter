using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DataImporter.Core.Models
{
    public class Feed
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Path { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Feed>(this);
    
        
    }
}
