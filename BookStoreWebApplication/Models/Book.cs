using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApplication.Models;

public partial class Book
{
    public int Id { get; set; }

    [Display(Name = "Рік видавництва")]
    public short PublicationYear { get; set; }

    [Display(Name = "Тип обкладинки")]
    public string? CoverType { get; set; }

    [Display(Name = "Ціна")]
    public double Price { get; set; }

    [Display(Name = "Назва")]
    public string Name { get; set; }

    [Display(Name = "Жанри")]
    public virtual string Genres
    {
        get
        {
            //return $"{BooksGenres.Count}";
            return string.Join(", ", BooksGenres.Select(b => b.Genre.Name));
        }
    }

    public virtual ICollection<AuthorsBook> AuthorsBooks { get; } = new List<AuthorsBook>();

    public virtual ICollection<Availability> Availabilities { get; } = new List<Availability>();

    public virtual ICollection<BooksGenre> BooksGenres { get; } = new List<BooksGenre>();


    //[NonSerialized]
    [Display(Name = "Жанри")]
    public virtual ICollection<int> GenreIds { get; } = new List<int>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
