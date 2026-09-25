using System;
using System.Collections.Generic;

namespace Firmeza.Infrastructure.Persistence.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string UnitOfMeasure { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public decimal CurrentStock { get; set; }

    public decimal MinimumStock { get; set; }

    public bool IsActive { get; set; }

    public int ProductCategoryId { get; set; }

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
