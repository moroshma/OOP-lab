﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Models
{
    public class BookGenre
    {
        public int BookGenreId { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
