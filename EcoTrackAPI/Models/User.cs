using System;
using System.Collections.Generic;

namespace EcoTrackAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Role { get; set; }

    public string? Phone { get; set; }

    public decimal? Balance { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

public class UserLoginDTO
{
    public string username { get; set; } = null!;
    public string password { get; set; } = null!;
}

public class CustomerRegisterDTO
{
    public string username { get; set; } = null!;
    public string password { get; set; } = null!;
    public string fullName { get; set; } = null!;
    public string phone { get; set; } = null!;

    public User toUser()
    {
        return new User { Username = username, FullName = fullName, Password = password, Balance = 0m, Role = "customer" };
    }
}
