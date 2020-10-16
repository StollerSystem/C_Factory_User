using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult Create(Incident Incident)
    {
      _db.Incidents.Add(Incident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Incident thisIncident = _db.Incidents
      // .Include(Incident => Incident.Clients)
      // .Include(Incident => Incident.Appointments)
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
  }
}