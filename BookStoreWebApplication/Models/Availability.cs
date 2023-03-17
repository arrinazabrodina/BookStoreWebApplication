using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApplication.Models;

public partial class Availability
{
    public int Id { get; set; }

    [Display(Name = "Книга")]
    public int BookId { get; set; }

    [Display(Name = "Магазин")]
    public int BookstoreId { get; set; }

    [Display(Name = "Кількість")]
    public int Count { get; set; }

    [Display(Name = "Книга")]
    public virtual Book Book { get; set; } = null!;
    
    [Display(Name = "Магазин")]
    public virtual Bookstore Bookstore { get; set; } = null!;
}
