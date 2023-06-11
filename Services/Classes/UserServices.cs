using Services.Models;
using Services.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class UserServices
    {
        FinalPrjContext _context;

        public String ErrorMesage { get; set; }
      


        public List<UserVM> GetUsers() {

            _context = new FinalPrjContext();

            List<UserVM> result = new List<UserVM>();
          
            var list = _context.UsersTables.ToList();
           
            foreach (var user in list)
            {
                UserVM vm = new UserVM();  
                vm.Id = user.Id;
                vm.Name = user.Name;
                vm.LastName = user.LastName;
                vm.Email = user.Email;
                vm.Password = user.Password;
                vm.Adress = user.Adress;
                vm.BirthDate = user.BirthDate;
                result.Add(vm);

            }
        
            return result;
        }



        public bool AddUsers(UserVM vm) {

            _context = new FinalPrjContext();

            var ControllModel = _context.UsersTables.Find(vm.Email);

            if (ControllModel == null)
            {
                var model = new UsersTable();
                model.Name = vm.Name;
                model.LastName = vm.LastName;
                model.Email = vm.Email;
                model.Password = vm.Password;
                model.Adress = vm.Adress;   
                model.BirthDate = (DateTime)vm.BirthDate; 


                _context.UsersTables.Add(model);
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


        public bool EditUsers(UserVM vm)
        {
            _context = new FinalPrjContext();


            var model = _context.UsersTables.Find(vm.Id);

            if (model != null)
            {
                model.Name = vm.Name;
                model.LastName=vm.LastName;
                model.Email = vm.Email;
                model.Password = vm.Password;
                model.Adress = vm.Adress;
                model.BirthDate = (DateTime)vm.BirthDate;

                _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                ErrorMesage = "Güncelleme Yapıldı.";

                return true;

            }else {

                ErrorMesage = "Güncelleme Yapılamadı.";
                return false; 
            }
        }

        public bool DeleteUsers(long id)
        {
            _context = new FinalPrjContext();

            var model = _context.UsersTables.Find(id);

            if (model != null)
            {
               _context.UsersTables.Remove(model);  
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




        public bool CheckUsers(string email,string pass)
        {

            _context = new FinalPrjContext();

            var ControllModel = _context.UsersTables.Where(x=> (x.Email==email && x.Password == pass)).FirstOrDefault();


            if (ControllModel != null )
            {

                return true;

            }

            ErrorMesage = "Kullanıcı Adı ya da Şifre Hatalı";
            return false;

        }

    }
}
