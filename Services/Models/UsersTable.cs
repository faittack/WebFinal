using System;
using System.Collections.Generic;

namespace Services.Models;

public partial class UsersTable
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public DateTime? BirthDate { get; set; }
}
