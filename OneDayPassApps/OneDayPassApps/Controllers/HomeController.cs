using OneDayPassApps.Models;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace oneDayPass.Controllers
{
    public class HomeController : Controller
    {
        OneDayPassEntities db = new OneDayPassEntities();
        public ActionResult Index(int k=0)
        {
            switch (k)
            {
                case 1:
                    return RedirectToAction("A1");
                    break;
                case 2:
                    return RedirectToAction("A2");
                    break;
                case 3:
                    return RedirectToAction("A3");
                    break;
                default:
                    break;
            }
            return View();
        }
        public ActionResult A1()
        {
            return View();
        }
        public ActionResult A2()
        {
            return View();
        }
        public ActionResult A3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult savePass(Pass model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Contact");
            //return View();
        }

        [HttpPost]
        public ActionResult ApplyTempPass(Pass model)
        {
            Hashtable map = new Hashtable(10);
            string error = "";
            Console.WriteLine("User Name" + model.userName);
            if (string.IsNullOrEmpty(model.userName))
            {
                error = "userName error";
                map.Add("error", error);
            }
            ViewBag.Message = "Your application description page.";


            return Json(map);
        }
        [HttpPost]
        public async Task<ActionResult> OneDayPass(Pass model)
        {
            ViewBag.Message = "Your contact page.";
            model.createDate = DateTime.Now;
            db.Entry(model).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            // string postUrl = "http://api.message.net.tw/send.php?id=0937018681&password=Tkd@0328kid&tel=" + model.phone + "&msg=<![CDATA[國立台北科技大學防疫期間一日通行證 https://localhost:44353/home/showPass?id=" + model.id + "]]>&mtype=G";
            string postUrl = "http://api.message.net.tw/send.php?id=0937018681&password=Tkd@0328kid&tel=0901202898&msg=國立台北科技大學防疫期間一日通行證&mtype=G";

            //建立 HttpClient 
          //  var client = new HttpClient();

           
            //使用 async 方法從網路 url 上取得回應
            return View(model);
        }

        public ActionResult showPass(string id)
        {
            Pass model = db.Pass.Where(x => x.id.Equals(id)).FirstOrDefault();
            return View(model);
        }
    }
}