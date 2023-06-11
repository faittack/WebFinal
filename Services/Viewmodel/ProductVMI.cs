using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Viewmodel
{
    public class ProductVMI
    {
        public long Id { get; set; }

        public string ProductName { get; set; } = null!;

        public long ProductCategory { get; set; }

        public string ProductCategoryName { get; set; }

        public decimal ProductPrize { get; set; }

        public long ProductStock { get; set; }

        public IFormFile ProductImage { get; set; } = null!;

        

    }
}
