using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Buyer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
