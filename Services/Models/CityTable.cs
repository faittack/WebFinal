using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class CityTable
{
    public long Id { get; set; }

    public string City { get; set; } = null!;
}
