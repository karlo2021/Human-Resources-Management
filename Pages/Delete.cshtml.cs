using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.Pages
{

    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {

        public DeleteModel(IPersonRepository repo) {
            Repository = repo;   
        }

        public IPersonRepository Repository { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Person Person { get; set; }
        public async Task<IActionResult> OnGetAsync(){
            if (string.IsNullOrEmpty(Id)) {
                return RedirectToPage("Store", new { Label = "Delete Person", Callback = "Delete" });
            }
            Person = await Repository.GetPersonByIdAsync(Id);
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync() {
            Person = await Repository.GetPersonByIdAsync(Id);
            await Repository.DeletePersonAsync(Person);
            return RedirectToPage("Landing");
        }
    }
}