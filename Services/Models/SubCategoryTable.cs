using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class SubCategoryTable
{
    public long Id { get; set; }

    public string SubCategory { get; set; } = null!;

    public long CategoryId { get; set; }

    public virtual CategoryTable Category { get; set; } = null!;
}
