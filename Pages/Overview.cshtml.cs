using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{

    [Authorize(Roles = "Admin")]
    public class OverviewModel : PageModel
    {

        public OverviewModel(IPersonRepository repo, PersonDbContext ctx) {
            Repository = repo;   
            DbContext = ctx;
        }
        public IPersonRepository Repository { get; set; }
        public PersonDbContext DbContext { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Callback { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Label { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime DateFrom { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime DateTo { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Record> Records { get; set; }
        public IActionResult OnGet(){
            if (string.IsNullOrEmpty(Callback)) {
                return RedirectToPage("Overview", new { Label = "Person", Callback = "Edit" });
            }
            if (Criteria == "Rating" || Criteria == "Interests" || Criteria == "EmpDate"
                || Criteria == "IntDate") {
                Records = CriteriaFilterRecord();
            } else {
                Persons = CriteriaFilter();
            }
            return Page();
        }
        
        private IEnumerable<Record> CriteriaFilterRecord() {
            switch(Criteria) {
                case "Rating": 
                    return DbContext.Records
                    .Where(p => Filter == null || 
                            p.Rating.ToString().ToLower().Contains(Filter.ToLower()))
                        .OrderBy(u => u.Rating).ToList();
                case "Interests":
                    return DbContext.Records
                    .Where(p => Filter == null || p.Interests.ToLower().Contains(Filter.ToLower()))
                        .OrderBy(u => u.Interests).ToList();
                case "EmpDate":
                    return DateFrom == DateTime.MinValue 
                        ? DbContext.Records.OrderBy(r => r.EmploymentDate).ToList() 
                        : DbContext.Records
                            .Where(rec => rec.EmploymentDate > (DateFrom) && rec.EmploymentDate < DateTo)
                            .OrderBy(u => u.EmploymentDate).ToList();
                case "IntDate":
                    return DateFrom == DateTime.MinValue 
                        ? DbContext.Records.OrderBy(r => r.InterviewDate).ToList() 
                        : DbContext.Records
                            .Where(rec => rec.InterviewDate > (DateFrom) && rec.InterviewDate < DateTo)
                            .OrderBy(u => u.InterviewDate).ToList();
                default:
                    return DbContext.Records.ToList();
            }
        }
        private IEnumerable<Person> CriteriaFilter() {
            switch(Criteria) {
                case "Name": 
                    return DbContext.Persons
                    .Where(p => Filter == null || p.Name.Contains(Filter))
                    .OrderBy(u => u.Name).Include(p => p.Records).ToList();
                case "Surname": 
                    return DbContext.Persons
                    .Where(p => Filter == null || p.Surname.Contains(Filter))
                    .OrderBy(u => u.Surname).Include(p => p.Records).ToList();
                case "Workplace": 
                    return DbContext.Persons
                    .Where(p => Filter == null || p.Workplace.Contains(Filter))
                    .OrderBy(u => u.Workplace).Include(p => p.Records).ToList();
                case "EmpDate": 
                    return DbContext.Persons
                    .Where(p => Filter == null || p.Workplace.Contains(Filter))
                    .OrderBy(u => u.Workplace).Include(p => p.Records).ToList();
                default:
                    return DbContext.Persons
                    .Where(p => Filter == null || p.Name.Contains(Filter))
                    .OrderBy(u => u.Name).Include(p => p.Records).ToList();
            }
        }
        public IActionResult OnPost() => RedirectToPage(new { Filter, Criteria, DateFrom, DateTo, Callback });
    }
}