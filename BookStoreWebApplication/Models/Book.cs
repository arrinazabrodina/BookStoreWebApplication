using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Book
{
    public int Id { get; set; }

    public short PublicationYear { get; set; }

    public string? Genre { get; set; }

    public string? CoverType { get; set; }

    public double Price { get; set; }

    public virtual ICollection<AuthorsBook> AuthorsBooks { get; } = new List<AuthorsBook>();

    public virtual ICollection<Availability> Availabilities { get; } = new List<Availability>();

    public virtual ICollection<BooksGenre> BooksGenres { get; } = new List<BooksGenre>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
