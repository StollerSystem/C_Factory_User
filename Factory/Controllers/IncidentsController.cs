using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class IncidentsController : Controller
  {
    private readonly FactoryContext _db;

    public IncidentsController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Incident> model = _db.Incidents.ToList();
      return View(model);
    }

    public ActionResult Create()
    {      
      return View();
    }

    [HttpPost]
    public ActionResult Create(Incident Incident, int EngineerId, int MachineId)
    {
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