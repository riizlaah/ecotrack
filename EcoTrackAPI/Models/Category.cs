using System;
using System.Collections.Generic;

namespace EcoTrackAPI.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? PricePerKg { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
