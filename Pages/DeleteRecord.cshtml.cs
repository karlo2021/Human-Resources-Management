using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Pages
{

    [Authorize(Roles = "Admin")]
    public class DeleteRecordModel : PageModel
    {

        public DeleteRecordModel(IRecordRepository repo) {
            Repository = repo;   
        }

        public IRecordRepository Repository { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Callback { get; set; }
        public Record Record { get; set; }
        public async Task<IActionResult> OnGetAsync(){
            if (!string.IsNullOrEmpty(Id)) {
                Record = await Repository.FindRecordByIdAsync(int.Parse(Id));
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync() {
            Record = await Repository.FindRecordByIdAsync(int.Parse(Id));
            await Repository.DeleteRecordAsync(Record);
            return RedirectToPage("Landing");
        }
    }
}