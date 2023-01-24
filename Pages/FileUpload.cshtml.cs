using System.ComponentModel.DataAnnotations;
using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages;

public class FileUploadModel : PageModel
{
    [Required]
    public IFormFile  FileUpload { get; set; }
    private readonly IPersonRepository repo;
    private readonly IFileUploadService fileUploadService;
    public FileUploadModel(IPersonRepository rep, IFileUploadService file) {
        repo = rep;
        fileUploadService = file;
    } 
        
    public Person Person { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }
    public async Task<IActionResult> OnGetAsync() {
        
        Person = await repo.GetPersonByIdAsync(Id.ToString());
        if (Person == null) {
            return RedirectToPage("Overview");
        }
        return Page();
    }
    public async Task<IActionResult> OnPost(IFormFile file) {
        if (!string.IsNullOrEmpty(Id)) {
            Person = await repo.GetPersonByIdAsync(Id.ToString());
            Person.CvDoc = file.FileName;
            await repo.SavePerson(Person);

            if (file != null) {
                await fileUploadService.UploadFile(file);
            }
        }
        return RedirectToPage("Overview");
    }
}
