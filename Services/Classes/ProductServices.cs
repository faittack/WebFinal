using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    internal class ProductServices
    {

        FinalPrjContext _context;

        public String ErrorMesage { get; set; }

        public List<ProductVM> GetProduct()
        {

            _context = new FinalPrjContext();

            List<ProductVM> result = new List<ProductVM>();

            var list = _context.ProductTables.ToList();

            foreach (var product in list)
            {
                ProductVM vm = new ProductVM();

                vm.Id = product.Id;
                vm.ProductName = product.ProductName;
                vm.ProductPrize = product.ProductPrize;
                vm.ProductStock = product.ProductStock;
                vm.ProductCategory = product.ProductCategory;
                vm.ProductImage = product.ProductImage;
                
                result.Add(vm);

            }

            return result;
        }




    }
}
