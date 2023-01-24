using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages;

public class RecordsModel : PageModel {
    private PersonDbContext DbContext;
    public IArrows Arrows;
    public RecordsModel(PersonDbContext ctx, IArrows arr) {
        DbContext = ctx;
        Arrows = arr;
    }
 
    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }

    public Person Person { get; set; }
    public List<Record> Records { get; set; }

    public string Idr { get; set; }

    public async Task<IActionResult> OnGetAsync() {
        if (string.IsNullOrEmpty(Id)) {
            return RedirectToPage("Store", new { Label = "Person Records", Callback = "Records" });
        }
        Person = DbContext.Persons.Where(p => p.Id == int.Parse(Id)).Include(r => r.Records).FirstOrDefault();
        Records = Person.Records.ToList();

        Arrows.HasNextPrev(Id);

        return Page();
    }
   
    
}