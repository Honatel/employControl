using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employesControl_V2.Models;

namespace employesControl_V2.Services.interfaces
{
    public interface IUserService
    {
        public Task<bool> UserIsValid(string UserName, string Password);

        public Task<User> FindByUserName(string UserName);

    }
}