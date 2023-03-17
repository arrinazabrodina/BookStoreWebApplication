using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApplication.Models;

public partial class Order
{
    public int Id { get; set; }

    public int BuyerId { get; set; }

    [Display(Name = "Дата замовлення")]
    public DateTime Date { get; set; }

    public int SellerId { get; set; }

    [Display(Name = "Ціна")]
    public float Price { get; set; }

    public string Title
    {
        get
        {
            return $"{Price}";
        }
    }

    [Display(Name = "Покупець")]
    public virtual Buyer Buyer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    [Display(Name = "Продавець")]
    public virtual Worker Seller { get; set; } = null!;
}
