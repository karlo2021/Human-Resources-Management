using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityApp.Models.ViewModels;

namespace IdentityApp.Pages;

[Authorize]
public class StoreModel : PageModel
{
    public StoreModel(PersonDbContext ctx) => DbContext = ctx;

    public PersonDbContext DbContext { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string Label { get; set; }

    
    [BindProperty(SupportsGet = true)]
    public string Callback { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Filter { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Criteria { get; set; }
    [BindProperty(SupportsGet = true)]    
    public string PersonPage {get; set;}
    public IEnumerable<Person> Persons { get; set; }
    public int PageSize = 4;
    public PersonListViewModel PageModel { get; set; }

    public string[] PropertyNames ;
    
    public void Random() {
        PropertyNames = new string[PageModel.PagingInfo.TotalPages];
        for ( int i = 1; i <= PageModel.PagingInfo.TotalPages ; i++) {
            PropertyNames[i-1] = i.ToString();
        }
    }
    public void OnGet(int personPage = 1) {

        PageModel = new PersonListViewModel {
            Persons = CriteriaFilter(personPage),
            PagingInfo = new PagingInfo {
                CurrentPage = personPage,
                ItemsPerPage = PageSize,
                TotalItems = DbContext.Persons.Count()
            }
        };
        Random();
    }

    private IEnumerable<Person> CriteriaFilter(int personPage) {
        switch(Criteria) {
            case "Id": 
                return DbContext.Persons
                .Where(p => Filter == null || p.Id.ToString().Contains(Filter))
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Id).ToList();
            case "Name": 
                return DbContext.Persons
                .Where(p => Filter == null || p.Name.Contains(Filter))
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Name).ToList();
            case "Surname": 
                return DbContext.Persons
                .Where(p => Filter == null || p.Surname.Contains(Filter))
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Surname).ToList();
            case "Workplace": 
                return DbContext.Persons
                .Where(p => Filter == null || p.Workplace.Contains(Filter))
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Workplace).ToList();
            default:
                return DbContext.Persons
                .Where(p => Filter == null || p.Name.Contains(Filter))
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Name).ToList();
        }
    }
    public IActionResult OnPost() => RedirectToPage(new { Filter, Criteria, Callback, PersonPage });

}
