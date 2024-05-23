﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Models
{
    public class Author
    {

        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
