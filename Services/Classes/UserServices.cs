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


        public List<UserVM> AddUsers() { 
        _context = new FinalPrjContext(); 
        List<UserVM> result = new List<UserVM>();
            var list = _context.Users.ToList();
            foreach (var user in list)
            {
                UserVM vm = new UserVM();  
                vm.Id = user.Id;
                vm.Name = user.Name;
                vm.Email = user.Email;
                vm.Password = user.Password;
                result.Add(vm);

            }
        
            return result;
        }


    }
}
