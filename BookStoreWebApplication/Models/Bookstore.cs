using System;
using System.Collections.Generic;

namespace BookStoreWebApplication.Models;

public partial class Bookstore
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Availability> Availabilities { get; } = new List<Availability>();

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();

    //public string? FullAddress
    //{
    //    get
    //    {
    //        if (City != null && Address != null)
    //        {
    //            return City + ", " + Address;
    //        }
    //        if (City != null)
    //        {
    //            return City;
    //        }
    //        if (Address != null)
    //        {
    //            return Address;
    //        }
    //        return null;
    //    }
    //}
}
