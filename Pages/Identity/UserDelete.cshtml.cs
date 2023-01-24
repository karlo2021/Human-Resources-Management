using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace IdentityApp.Pages.Identity;

public class UserDeleteModel : UserPageModel {
    public UserDeleteModel(UserManager<IdentityUser> usrMgr, SignInManager<IdentityUser> signMgr) {
        UserManager = usrMgr;
        SignInManager = signMgr;
    }
    public UserManager<IdentityUser> UserManager { get; set; }
    public SignInManager<IdentityUser> SignInManager{ get; set; }
    public async Task<IActionResult> OnPostAsync() {
        IdentityUser user = await UserManager.GetUserAsync(User);
        IdentityResult result = await UserManager.DeleteAsync(user);
        if (result.Process(ModelState)) {
            await SignInManager.SignOutAsync();
            return Challenge();
        }
        await SignInManager.SignOutAsync();
        return Challenge();
    }
}