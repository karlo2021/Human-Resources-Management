using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.Pages;

[Authorize(Roles = "Admin")]
public class AdminModel : PageModel
{
    public AdminModel(PersonDbContext ctx) => DbContext = ctx;

    public PersonDbContext DbContext { get; set; }

    public IActionResult OnPost(long id)
    {
        Person? p = DbContext.Find<Person>(id);
        if (p != null)
        {
            DbContext.Remove(p);
            DbContext.SaveChanges();
        }
        return Page();
    }
}
