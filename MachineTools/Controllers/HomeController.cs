using MachineTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTools.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();

        public ActionResult Index()
        {
            var machineTools = db.MachineTools.ToList();
            return View(machineTools);
        }

        public ActionResult Create()
        {
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
    }
}