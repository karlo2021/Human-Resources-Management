using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages;

public class LandingModel : PageModel
{
    public LandingModel(PersonDbContext ctx) => DbContext = ctx;

    public PersonDbContext DbContext { get; set; }
}
