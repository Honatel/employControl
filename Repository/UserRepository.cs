using employesControl_V2.Data;
using employesControl_V2.Models;
using employesControl_V2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace employesControl_V2.Repository
{
    public class UserRepository : IUserRepository
    {

        // public async static Task<User> Get(string UserName, string Password)
        // {
        //     var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        //     optionsBuilder.UseNpgsql("User Id=postgres; Password=postgres; Host=localhost; Port=5432; Database=dbFuncionario");
        //     var _context = new DataContext(optionsBuilder.Options);

        //     var users = await _context.Users.ToListAsync();

        //     return users.Where(x =>
        //              x.UserName.ToLower() == UserName.ToLower() &&
        //              x.Password.ToLower() == Password.ToLower())
        //                  .FirstOrDefault();
        // }

        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> FindByUserName(string UserName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower());
        }
    }
}