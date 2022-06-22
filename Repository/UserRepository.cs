using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employesControl_V2.Models;

namespace employesControl_V2.Repository
{
    public static class UserRepository
    {
        public static User Get(string UserName, string Password)
        {
            var users = new List<User>
            {
                new User{Id= 1, UserName = "hona", Password= "hona", Role= "manager"},
                new User{Id= 2, UserName = "marcos", Password= "hona", Role= "employee" }
            };

            return users.Where(x => x.UserName.ToLower() == UserName.ToLower() && x.Password.ToLower() == Password.ToLower()).FirstOrDefault();
        }
    }
}