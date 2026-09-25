using System;
using System.Collections.Generic;

namespace Firmeza.Infrastructure.Persistence.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string DocumentType { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
