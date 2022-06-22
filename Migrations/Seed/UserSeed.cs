using employesControl_V2.Data;
using employesControl_V2.Models;

namespace employesControl_V2.Migrations.Seed
{
    public static class UserSeed
    {
        public async static void run(DataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User() { UserName = "admin", Password = Helper.DataProtection.EncriptiStringValue("admin"), Role = "manager" });
                await context.SaveChangesAsync();
            }
        }
    }
}