using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private PersonDbContext DbContext;
    public AdminController(PersonDbContext ctx) => DbContext = ctx;
    public IActionResult Index() => View(DbContext.Persons);

    [HttpGet]
    public IActionResult Create() => View("Edit", new Person());

    [HttpPost]
    public IActionResult Save(Person p)
    {
        DbContext.Update(p);
        DbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(long id)
    {
        Person p = DbContext.Find<Person>(id);
        if (p != null)
        {
            return View("Edit", p);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(long id)
    {
        Person p = DbContext.Find<Person>(id);
        if (p != null)
        {
            DbContext.Remove(p);
            DbContext.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }


}

