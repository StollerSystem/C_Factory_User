using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
// /new using directives
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Factory.Controllers
{
  [Authorize] //new line
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //new line
    public EngineersController(UserManager<ApplicationUser> userManager, FactoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<Engineer> userEngineers = _db.Engineers.Where(entry => entry.User.Id == currentUser.Id).ToList();;

      // List<Engineer> model = _db.Engineers.OrderBy(x => x.EngineerName).ToList();
      return View(userEngineers);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Engineer engineer)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      engineer.User = currentUser; //"STAMP" USER ON THE OBJECT
      _db.Engineers.Add(engineer);
      // if (CategoryId != 0)
      // {
      //   _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
      // }
      _db.SaveChanges();


      // _db.Engineers.Add(Engineer);
      // _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer model = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer Engineer)
    {
      _db.Entry(Engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(x => x.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //  MACHINE
    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineers => Engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult AddMachine(Engineer Engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = Engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = Engineer.EngineerId });
    }

    [HttpPost]
    public ActionResult DeleteMachine(int engineerId, int joinId)
    {
      var joinEntry = _db.MachineEngineers.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
      _db.MachineEngineers.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineerId });
    }

    [HttpPost] // SEARCH
    public ActionResult Index(string name)
    {
      List<Engineer> model = _db.Engineers.Where(x => x.EngineerName.Contains(name)).ToList();      
      List<Engineer> sortedList = model.OrderBy(o => o.EngineerName).ToList();
      ViewBag.filterName = "Filtering by: "+name;
      return View("Index", sortedList);
    }
  }
}