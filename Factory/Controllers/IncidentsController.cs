using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
// /new using directives
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Factory.Controllers
{
  [Authorize] 
  public class IncidentsController : Controller
  {
    private readonly FactoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 
    public IncidentsController(UserManager<ApplicationUser> userManager,FactoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task <ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      List<Incident> model = _db.Incidents.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(model);
    }

    public ActionResult Create()
    {      
      return View();
    }

    [HttpPost]
    public async Task <ActionResult> Create(Incident Incident, int EngineerId, int MachineId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Incident.User = currentUser;
      _db.Incidents.Add(Incident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Incident thisIncident = _db.Incidents      
      .FirstOrDefault(Incident => Incident.IncidentId == id);
      return View(thisIncident);
    }

    public ActionResult Edit(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(Incident => Incident.IncidentId == id);
      return View(thisIncident);
    }

    [HttpPost]
    public ActionResult Edit(Incident Incident)
    {
      _db.Entry(Incident).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(Incident => Incident.IncidentId == id);
      return View(thisIncident);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(Incident => Incident.IncidentId == id);
      _db.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost] // Search
    public ActionResult Index(string name)
    {
      List<Incident> model = _db.Incidents.Where(x => x.IncidentTitle.Contains(name)).ToList();      
      List<Incident> sortedList = model.OrderBy(o => o.IncidentTitle).ToList();
      ViewBag.filterName = "Filtering by: "+name;
      return View("Index", sortedList);
    }

    // AddEngMach
    public ActionResult AddEngMach(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(Incidents => Incidents.IncidentId == id);

      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");

      return View(thisIncident);
    }
    [HttpPost]
    public ActionResult AddEngMach(Incident Incident, int EngineerId, int MachineId)
    {
      if (EngineerId != 0 && MachineId != 0)
      {
        _db.IncidentJoins.Add(new IncidentJoin() { MachineId = MachineId, EngineerId = EngineerId, IncidentId = Incident.IncidentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = Incident.IncidentId });
    }
  }
}