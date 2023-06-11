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
    public class ProductServices
    {

        FinalPrjContext _context;

        public String ErrorMesage { get; set; }

        public List<ProductVM> GetProductForAdmin()
        {

            _context = new FinalPrjContext();

            List<ProductVM> result = new List<ProductVM>();

         


            var list = _context.ProductTables.Include(a => a.CategoryTable).ToList();

            foreach (var product in list)
            {
                ProductVM vm = new ProductVM();

                vm.Id = product.Id;
                vm.ProductName = product.ProductName;
                vm.ProductPrize = product.ProductPrize;
                vm.ProductStock = product.ProductStock;
                vm.ProductCategory = product.ProductCategory;
                vm.ProductCategoryName = product.CategoryTable.Category;
                vm.ProductImage = product.ProductImage;
                
                result.Add(vm);

            }

            return result;
        }


        public List<ProductVM> GetProductForClients()
        {

            _context = new FinalPrjContext();

            List<ProductVM> result = new List<ProductVM>();

            var list = _context.ProductTables.Include(a=>a.CategoryTable).Where(x => x.ProductStock > 0).ToList();

            foreach (var product in list)
            {
                ProductVM vm = new ProductVM();

                vm.Id = product.Id;
                vm.ProductName = product.ProductName;
                vm.ProductPrize = product.ProductPrize;
                vm.ProductStock = product.ProductStock;
                vm.ProductCategory = product.ProductCategory;
                vm.ProductCategoryName = product.CategoryTable.Category;
                vm.ProductImage = product.ProductImage;

                result.Add(vm);

            }

            return result;
        }

        //public List<ProductVM> SearchProductForClients(int min,int max,string category )
        //{
            

        //    _context = new FinalPrjContext();

        //    List<ProductVM> result = new List<ProductVM>();

        //    string sql = "x => x.ProductStock > 0";



        //    var list = _context.ProductTables.Where(x => x.ProductStock > 0 && x.ProductPrize> value && x.ProductCategory == vm.Category).ToList();

        //    foreach (var product in list)
        //    {
        //        ProductVM vm = new ProductVM();

        //        vm.Id = product.Id;
        //        vm.ProductName = product.ProductName;
        //        vm.ProductPrize = product.ProductPrize;
        //        vm.ProductStock = product.ProductStock;
        //        vm.ProductCategory = product.ProductCategory;
        //        vm.ProductImage = product.ProductImage;

        //        result.Add(vm);

        //    }

        //    return result;
        //}







        public bool AddProduct(ProductVMI vm)
        {

            _context = new FinalPrjContext();
          

            if (true)
            {
                var model = new ProductTable();

                if (vm.ProductImage != null) {
                
                    var extension = Path.GetExtension(vm.ProductImage.FileName);
                    var newimagename= Guid.NewGuid() + extension;   
                    var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/" , newimagename );
                    var stream = new FileStream(location, FileMode.Create);
                    vm.ProductImage.CopyTo(stream);
                    model.ProductImage = newimagename;
               
                }

                model.Id = vm.Id;
                model.ProductName = vm.ProductName;
                model.ProductCategory=vm.ProductCategory;
                model.ProductPrize = vm.ProductPrize;
                model.ProductStock = vm.ProductStock;
             


                _context.ProductTables.Add(model);
                _context.SaveChanges();

                ErrorMesage = "Ekleme Başarılı.";
                return true;

            }
            else
            {
                ErrorMesage = "Ekleme Başarısız.";
                return false;
            }

        }


        public bool EditProduct(ProductVMI vm)
        {
            _context = new FinalPrjContext();


            var ControllModel = _context.ProductTables.Find(vm.Id);


            if (ControllModel != null)
            {
                var model = new ProductTable();

                if (vm.ProductImage != null)
                {

                    var extension = Path.GetExtension(vm.ProductImage.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "~/Images/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    vm.ProductImage.CopyTo(stream);
                    model.ProductImage = newimagename;

                }

                model.Id = vm.Id;
                model.ProductName = vm.ProductName;
                model.ProductCategory = vm.ProductCategory;
                model.ProductPrize = vm.ProductPrize;
                model.ProductStock = vm.ProductStock;

                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                ErrorMesage = "Güncelleme Yapıldı.";

                return true;

            }
            else
            {
                ErrorMesage = "Güncelleme Yapılamadı.";
                return false;
            }

        }



        public bool DeleteProduct(ProductVM vm)
        {
            _context = new FinalPrjContext();

            var model = _context.ProductTables.Find(vm.Id);

            if (model != null)
            {
                _context.ProductTables.Remove(model);
                _context.SaveChanges();

                ErrorMesage = "Silindi.";

                return true;

            }
            else
            {

                ErrorMesage = "Silinemedi.";
                return false;
            }
        }






    }
}
