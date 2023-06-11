using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Viewmodel
{
    public class SubCategoryVM
    {
        public long Id { get; set; }

        public string SubCategory { get; set; } = null!;

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

    }
}
