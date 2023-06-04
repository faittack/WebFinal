using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.Viewmodel
{
    public class UserVM
    {

        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
