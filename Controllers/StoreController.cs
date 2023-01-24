using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityApp.Models.ViewModels;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        public int PageSize = 4;
        private PersonDbContext DbContext;
        public StoreController(PersonDbContext ctx) => DbContext = ctx;
        public IActionResult Index(int personPage = 1) => View(new PersonListViewModel{
            Persons = DbContext.Persons
                .Skip((personPage - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(u => u.Name).ToList(),
            PagingInfo = new PagingInfo {
                CurrentPage = personPage,
                ItemsPerPage = PageSize,
                TotalItems = DbContext.Persons.Count()
            }
        });
    }
}