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
  [Authorize]
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public MachinesController(UserManager<ApplicationUser> userManager,FactoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public async Task <ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<Machine> model = _db.Machines.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Machine Machine)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Machine.User = currentUser; 
      _db.Machines.Add(Machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Machine model = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine Machine)
    {
      _db.Entry(Machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(x => x.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(x => x.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // ENGINEER
    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machines => Machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddEngineer(Machine Machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.MachineEngineers.Add(new MachineEngineer() { EngineerId = EngineerId, MachineId = Machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = Machine.MachineId });
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int machineId, int joinId)
    {
      var joinEntry = _db.MachineEngineers.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
      _db.MachineEngineers.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machineId });
    }

    [HttpPost] // SEARCH
    public ActionResult Index(string name)
    {
      List<Machine> model = _db.Machines.Where(x => x.MachineName.Contains(name)).ToList();      
      List<Machine> sortedList = model.OrderBy(o => o.MachineName).ToList();
      ViewBag.filterName = "Filtering by: "+name;
      return View("Index", sortedList);
    }
  }
}