using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Availability
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int BookstoreId { get; set; }

    public int Count { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Bookstore Bookstore { get; set; } = null!;
}
