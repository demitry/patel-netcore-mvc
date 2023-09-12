using BulkyBook.DataAccess.Data;
using BulkyBook.Models.Models;
using BulkyBook.Utility.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.DbInitializer
{
    internal class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            // Apply migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            // Create roles if they are not created
            if (!_roleManager.RoleExistsAsync(AppRole.Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(AppRole.Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Company)).GetAwaiter().GetResult();


                // If roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "dpoluektov@tutanota.com",
                    Email = "dpoluektov@tutanota.com",
                    Name = "Admin Admin",
                    PhoneNumber = "0679307850",
                    StreetAddress = "Main 123 Ave",
                    State = "IL",
                    PostalCode = "79008",
                    City = "Rome"
                }, "Admin123*").GetAwaiter().GetResult(); // I know, I know, OK, it is OK for the test App


                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@dotnetmastery.com");
                _userManager.AddToRoleAsync(user, AppRole.Admin).GetAwaiter().GetResult();

            }

            return;
        }
    }
}
