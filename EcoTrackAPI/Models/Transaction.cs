using System;
using System.Collections.Generic;

namespace EcoTrackAPI.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public decimal Weight { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime Date { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;

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

public class TransactionDetailDTO
{
    public int id { get; set; }
    public decimal weight { get; set; }
    public int categoryId { get; set; }
    public string categoryName { get; set; }
    public decimal totalPrice { get; set; }
    public DateTime createdAt { get; set; }

}