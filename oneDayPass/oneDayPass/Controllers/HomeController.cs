using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oneDayPass.Controllers
{
    public class HomeController : Controller
    {
        Models.OneDayPassDBEntities db = new Models.OneDayPassDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult savePass(Models.Pass model)
        {            
            db.Entry(model).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Contact");
            //return View();
        }

        [HttpPost]
        public ActionResult ApplyTempPass(Models.Pass model)
        {
            Hashtable map = new Hashtable(10);
            string error = "";
            Console.WriteLine("User Name"+ model.userName);
            if (string.IsNullOrEmpty(model.userName)) {
                error = "userName error";
                map.Add("error", error);
            }
            ViewBag.Message = "Your application description page.";
            
            
            return Json(map);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}