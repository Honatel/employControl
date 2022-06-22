using employesControl_V2.Models;

namespace employesControl_V2.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> FindByUserName(string UserName);
    }
}