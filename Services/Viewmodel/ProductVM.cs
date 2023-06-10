using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Viewmodel
{
    public class ProductVM
    {
        public long Id { get; set; }

        public string ProductName { get; set; } = null!;

        public long ProductCategory { get; set; }

        public decimal ProductPrize { get; set; }

        public long ProductStock { get; set; }

        public string ProductImage { get; set; } = null!;


    }
}
