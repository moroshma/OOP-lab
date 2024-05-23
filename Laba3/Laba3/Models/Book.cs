using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }
    }
}
