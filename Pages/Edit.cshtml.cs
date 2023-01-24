using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Pages
{
    

    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {

        public EditModel(PersonDbContext ctx, IPersonRepository repo) {
            DbContext = ctx;
            Repository = repo;   
        }

        public PersonDbContext DbContext { get; set; }
        public IPersonRepository Repository { get; set; }
        public Person Person { get; set; }

        public void OnGet(long id) {
            Person = DbContext.Find<Person>(id) ?? new Person();
        }

        public  IActionResult OnPost ([Bind(Prefix = "Person")]Person p)
        {
           if (ModelState.IsValid) {
                DbContext.Update(p);
                DbContext.SaveChanges();
                return RedirectToPage("Store", new { Label = "View Person", Callback = "View" });
            } 
            return Page();

        }
    }
}