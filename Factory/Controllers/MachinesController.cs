using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.OrderBy(x => x.MachineName).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine Machine)
    {
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
    // public ActionResult AddSpecialty(int id)
    // {
    //   Machine thisMachine = _db.Machines.FirstOrDefault(s => s.MachineId == id);
    //   ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "SpecialtyType");
    //   return View(thisMachine);
    // }
    // [HttpPost]
    // public ActionResult AddSpecialty(SpecialtyMachine specialtyMachine)
    // {
    //   if (specialtyMachine.SpecialtyId != 0)
    //   {
    //     if (_db.SpecialtyMachines.Where(x => x.SpecialtyId == specialtyMachine.SpecialtyId && x.MachineId == specialtyMachine.MachineId).ToHashSet().Count == 0)
    //     {
    //       _db.SpecialtyMachines.Add(specialtyMachine);
    //     }
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
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
  }
}