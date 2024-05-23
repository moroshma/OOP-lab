using System.ComponentModel.DataAnnotations.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace Laba3.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public string? Name { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }
    }
    
}
