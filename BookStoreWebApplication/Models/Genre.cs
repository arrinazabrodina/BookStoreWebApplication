using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AuthorsGenre> AuthorsGenres { get; } = new List<AuthorsGenre>();

    public virtual ICollection<BooksGenre> BooksGenres { get; } = new List<BooksGenre>();
}
