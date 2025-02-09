﻿namespace Mbzuh.Assessment.BookService.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = [];
    }
}
