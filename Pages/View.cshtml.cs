using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages;
public class ViewModel : PageModel
{
    private IPersonRepository Repository;
    public IArrows Arrows;
    public ViewModel(IPersonRepository repo, IArrows arr) {
        Repository = repo;
        Arrows = arr;
    }

    
    public Person Person { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }

    [BindProperty(SupportsGet = true)]
    public int PersonPage { get; set; }
    public IEnumerable<string> PropertyNames => typeof(Person).GetProperties()
        .Select(prop => prop.Name);

    public string GetValue(string name) {
        if (name != "Birth") {
            return typeof(Person).GetProperty(name)
                .GetValue(Person)?.ToString();
        } else {
            return Person.Birth.ToString("dd-MM-yyyy");
        }
    }    
    public IActionResult OnGet() {
        if (string.IsNullOrEmpty(Id)) {
            return RedirectToPage("Store", new { Label = "View Person", Callback = "View", PersonPage = PersonPage});
        }
        Person = Repository.GetPerson(Id);
        Arrows.HasNextPrev(Id);

        return Page();
    }
}