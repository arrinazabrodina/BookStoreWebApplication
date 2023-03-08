using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Genres { get; set; } = null!;

    public string? ShortBiography { get; set; }

    public virtual ICollection<AuthorsBook> AuthorsBooks { get; } = new List<AuthorsBook>();

    public virtual ICollection<AuthorsGenre> AuthorsGenres { get; } = new List<AuthorsGenre>();
}
