using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IdentityApp.Pages.Identity.Admin
{
    public class DashboardModel : PageModel
    {
        public DashboardModel(UserManager<IdentityUser> userMgr, IConfiguration configuration) {
            UserManager = userMgr;
            DashboardRole = configuration["Daashboard:Role"] ?? "Dashboard";
        } 
        public UserManager<IdentityUser> UserManager { get; set; }

        public string DashboardRole { get; set; }
        public int UsersCount { get; set; } = 0;
        public int UsersUnconfirmed { get; set; } = 0;
        public int UsersLockedout { get; set; } = 0;
        public int UsersTwoFactor { get; set; } = 0;

        private readonly string[] emails = {
            "alice@example.com", "bob@example.com", "charlie@example.com"
        };

        public void OnGet() {
            UsersCount = UserManager.Users.Count();
            UsersUnconfirmed = UserManager.Users.Where(u => !u.EmailConfirmed).Count();
            UsersLockedout = UserManager.Users
                .Where(u => u.LockoutEnabled && u.LockoutEnd > System.DateTimeOffset.Now)
                .Count();
        }
        public async Task<IActionResult> OnPostAsync() {
            foreach(IdentityUser existingUser in UserManager.Users.ToList()) {
                if (emails.Contains(existingUser.Email) || 
                        !await UserManager.IsInRoleAsync(existingUser, DashboardRole)) {
                    IdentityResult result = await UserManager.DeleteAsync(existingUser);
                    result.Process(ModelState);
                }
            }
            foreach(string email in emails) {
                IdentityUser user = new IdentityUser{
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                IdentityResult result = await UserManager.CreateAsync(user);  
                if (result.Process(ModelState)) {
                    result = await UserManager.AddPasswordAsync(user, "mysecret");
                    result.Process(ModelState);
                }
            }
            if (ModelState.IsValid) {
                return RedirectToPage();
            }
            return Page();
        }
    }
}
