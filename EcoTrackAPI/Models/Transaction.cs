using System;
using System.Collections.Generic;

namespace EcoTrackAPI.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Weight { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? Date { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}

public class TransactionCustomerDTO
{
    public decimal weight { get; set; }
    public int categoryId { get; set; }
    public Transaction toTransaction(int userId, decimal totalPrice)
    {
        return new Transaction { UserId = userId, CategoryId = categoryId, Weight = weight, TotalPrice = totalPrice };
    }
}