﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApplication.Models;

public partial class Bookstore
{
    public int Id { get; set; }

	[Display(Name = "Місто")]
	public string? City { get; set; }

	[Display(Name = "Адреса")]
	public string? Address { get; set; }

    public virtual ICollection<Availability> Availabilities { get; } = new List<Availability>();

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();

    [Display(Name = "Повна Адреса")]
    public string? FullAddress
    {
        get
        {
            if (City != null && Address != null)
            {
                return City + ", " + Address;
            }
            if (City != null)
            {
                return City;
            }
            if (Address != null)
            {
                return Address;
            }
            return null;
        }
    }
}
