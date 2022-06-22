using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employesControl_V2.Models;
using employesControl_V2.Repository.Interfaces;

namespace employesControl_V2.Services.interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> FindByUserName(string UserName)
        {
            return await _userRepository.FindByUserName(UserName);
        }

        public async Task<bool> UserIsValid(string UserName, string Password)
        {
            var user = await _userRepository.FindByUserName(UserName);
            if (user == null) return false;

            return user.Password == Helper.DataProtection.EncriptiStringValue(Password);
        }
    }
}