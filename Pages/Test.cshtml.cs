using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Pages
{

    [Authorize(Roles = "Admin")]
    public class TestModel : PageModel
    {

        public TestModel(PersonDbContext ctx, IPersonRepository repo) {
            DbContext = ctx;
            Repository = repo;   
        }

        public PersonDbContext DbContext { get; set; }
        public IPersonRepository Repository { get; set; }
        public Person Person { get; set; }

        public Month Month { get; set; }
        public Day Day { get; set; }
        public Degree Degree { get; set; }

        public async void OnGet(long id){ 
            Day = DbContext.Find<Day>(id) ?? new Day();
        }
        public async Task OnPostAddMonthAsync([Bind(Prefix = "Month")][Required] Month month) {
            if (!string.IsNullOrEmpty(month.Name)) {
                await Repository.AddMonthAsync(month);
            }
            RedirectToPage("Test", new { id="1"});
        }

        public async Task OnPostDeleteMonthAsync([Required] string monthName) {
            Month? month = Repository.Months.FirstOrDefault(m => m.Name == monthName);
            if (month != null) {
                await Repository.RemoveMonthAsync(month);
            }
            RedirectToPage("Test", new  { id="1"});
        }
        
        public async Task OnPostAddDayAsync([Bind(Prefix = "Day")][Required] Day day) {
            if (day.Name != default(int)) {
                await Repository.AddDayAsync(day);
            }
            RedirectToPage("Test");
        }

        public async Task OnPostDeleteDayAsync([Required] string dayName) {
            Day? day = Repository.Days.FirstOrDefault(d => d.Name.ToString() == dayName);
            if (day != null) {
                await Repository.RemoveDayAsync(day);
            }
            RedirectToPage("Test");
        }
        
        public async Task OnPostAddDegreeAsync([Bind(Prefix = "Degree")][Required] Degree degree) {
             if (!string.IsNullOrEmpty(degree.Name)) {
                await Repository.AddDegreeAsync(degree);
            }
            RedirectToPage("Test");
        }

        public async Task OnPostDeleteDegreeAsync([Required] string degreeName) {
            Degree? degree = Repository.Degrees.FirstOrDefault(d => d.Name == degreeName);
            if (degree != null) {
                await Repository.RemoveDegreeAsync(degree);
            }
            RedirectToPage("Test");
        }

        public  IActionResult OnPostSetBackgroundAsync([Required] string backgroundColor) {
            ViewData["theme"] = backgroundColor;
            return Page();
        }

        public  IActionResult OnPostAppearanceAsync([Bind(Prefix = "Day")] Day day) {
            Day = DbContext.Days.First<Day>();
            Day.BackgroundColor = day.BackgroundColor;
            Day.BannerText = day.BannerText;
            Day.SideNavColor = day.SideNavColor;
            if (ModelState.IsValid) {
                DbContext.Update(Day);
                DbContext.SaveChanges();
            } 
            return Page();
        }

        public IActionResult OnPostSelectFolder([Required] string folderDestination) {
            Day = DbContext.Days.First<Day>();
            Day.CvLocation = folderDestination;
            if (ModelState.IsValid) {
                DbContext.Update(Day);
                DbContext.SaveChanges();
            } 
            return Page();
        }
        
    }
}