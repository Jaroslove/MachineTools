using MachineTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MachineTools.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();

        public ActionResult Index()
        {
            var machineTools = db.MachineTools.Include(p => p.Category);
            return View(machineTools.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MachineTool machineTool)
        {
            machineTool.Id = Guid.NewGuid();
            db.MachineTools.Add(machineTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid? Id)
        {
            if (Id != null)
            {
                var machineTool = db.MachineTools.Find(Id);
                if (machineTool != null)
                {
                    ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
                    return View(machineTool);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MachineTool machineTool)
        {
            db.Entry(machineTool).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}