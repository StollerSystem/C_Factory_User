using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.OrderBy(x => x.EngineerName).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer Engineer)
    {
      _db.Engineers.Add(Engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Engineer model = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(model);
    }
    // public ActionResult AddSpecialty(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(s => s.EngineerId == id);
    //   ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "SpecialtyType");
    //   return View(thisEngineer);
    // }
    // [HttpPost]
    // public ActionResult AddSpecialty(SpecialtyEngineer specialtyEngineer)
    // {
    //   if (specialtyEngineer.SpecialtyId != 0)
    //   {
    //     if (_db.SpecialtyEngineers.Where(x => x.SpecialtyId == specialtyEngineer.SpecialtyId && x.EngineerId == specialtyEngineer.EngineerId).ToHashSet().Count == 0)
    //     {
    //       _db.SpecialtyEngineers.Add(specialtyEngineer);
    //     }
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
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
  }
}