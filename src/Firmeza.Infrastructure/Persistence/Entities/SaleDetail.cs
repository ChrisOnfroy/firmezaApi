using System;
using System.Collections.Generic;

namespace Firmeza.Infrastructure.Persistence.Entities;

public partial class SaleDetail
{
    public int Id { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
