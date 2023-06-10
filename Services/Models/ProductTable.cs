using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class ProductTable
{
    public long Id { get; set; }

    public string ProductName { get; set; } = null!;

    public long ProductCategory { get; set; }

    public decimal ProductPrize { get; set; }

    public long ProductStock { get; set; }

    public string ProductImage { get; set; } = null!;

    public virtual CategoryTable ProductCategoryNavigation { get; set; } = null!;
}
