using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practicemvc.Models;

namespace practicemvc.Controllers
{
    public class con1Controller : Controller
    {
        rep1 ob = new rep1();
        // GET: con1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(model1 obj1)
        {
            if(ModelState.IsValid)
            {
                ob.insert(obj1);
                return RedirectToAction("Display");
                
            }
            return View();
        }
        public ActionResult Display()
        {
            ModelState.Clear();
        return View(ob.display());
        }
        public ActionResult Update(int id)
        {
            return View(ob.display().Find(e => e.id == id));
        }
        [HttpPost]
        public ActionResult Update(model1 uob)
        {
            if(ModelState.IsValid)
            {
                ob.update(uob);
                return RedirectToAction("Display");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            ob.delete(id);
           return RedirectToAction("Display");
            
        }
    }
}