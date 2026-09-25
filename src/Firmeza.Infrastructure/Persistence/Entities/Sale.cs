using System;
using System.Collections.Generic;

namespace Firmeza.Infrastructure.Persistence.Entities;

public partial class Sale
{
    public int Id { get; set; }

    public string SaleNumber { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public string Status { get; set; } = null!;

    public string? DeliveryAddress { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Tax { get; set; }

    public decimal Total { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
