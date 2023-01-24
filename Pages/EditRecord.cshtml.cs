using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{

    [Authorize(Roles = "Admin")]
    public class EditRecordModel : PageModel
    {

        public EditRecordModel(PersonDbContext ctx) => DbContext = ctx;
        public PersonDbContext DbContext { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Idr { get; set; }

        public Person Person { get; set; }
        public Record Record { get; set; }


        public async  Task<IActionResult> OnGetAsync() {
            if (Id == null) {
                return RedirectToPage("Store", new { Label = "Create Record", Callback = "EditRecord" });
            }
            Person = DbContext.Persons.Where(p => p.Id == Id).Include(r => r.Records).FirstOrDefault();
            
            Record = String.IsNullOrEmpty(Idr) 
                ? new Record() {PersonId = Id}
                : Person.Records.Where(r => r.Id.ToString() == Idr).FirstOrDefault();
            return Page();
        }
        public IActionResult OnPost([Bind(Prefix = "Record")] Record r){
                r.PersonId = Id;
                DbContext.Update(r);
                DbContext.SaveChanges();
                return RedirectToPage("Overview");
        }
    }
}