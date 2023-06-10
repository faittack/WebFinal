using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class CategoryTable
{
    public long Id { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<ProductTable> ProductTables { get; set; } = new List<ProductTable>();
}
