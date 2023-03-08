using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Order
{
    public int Id { get; set; }

    public int BuyerId { get; set; }

    public DateTime Date { get; set; }

    public int SellerId { get; set; }

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual Worker Seller { get; set; } = null!;
}
