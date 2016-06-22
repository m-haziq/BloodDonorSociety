using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProj.Models;

namespace MvcProj.Controllers
{
    public class HomeController : Controller
    {
        myDatabaseEntities2 db = new myDatabaseEntities2();
        
        // GET: /Home/
        public ActionResult home()
        {
            if(Session["uroll"] == null)
            {
                return RedirectToAction("main", "Main");
            }
            else
            { 
                myPosts p = new myPosts();
                p.list = db.status.ToList();
                p.list.Reverse();

                return View(p);
            }
        }

        public ActionResult signout()
        {
            Session["uroll"] = null;
            return RedirectToAction("main", "Main");
        }
        public ActionResult bloodReq()
        {
            if (Session["uroll"] == null)
            {
                return RedirectToAction("main", "Main");
            }
            else
            {
                return View();
            }
        }
        public ActionResult history()
        {
            if (Session["uroll"] == null)
            {
                return RedirectToAction("main", "Main");
            }
            else
            {
                myPosts p = new myPosts();
                p.list = db.status.ToList();
                p.list.Reverse();

                return View(p);
            }
        }
        public ActionResult profile()
        {
            if (Session["uroll"] == null)
            {
                return RedirectToAction("main", "Main");
            }
            else
            {
                myPosts m = new myPosts();
                string roll = (string)Session["uid"];
                m.u = (from x in db.Users
                       where x.rollNumber == roll
                       select x).First();

                return View(m);
            }
        }
        public ActionResult News()
        {
            if (Session["uroll"] == null)
            {
                return RedirectToAction("main", "Main");
            }
            else
            {
                return View();
            }
        }
        public ActionResult postStatus(status m)
        {
            m.userRoll = (string)Session["uid"];
            db.status.Add(m);
            db.SaveChanges();
            return RedirectToAction("home");
        }
        public JsonResult ShowDonors()
        {
            string userName = Request["MovieType"];
            if(userName == "A ")
            {
                userName = "A+";
            }
            else if(userName == "B ")
            {
                userName = "B+";
            }
            else if(userName == "O ")
            {
                userName = "O+";
            }
            else if(userName == "AB ")
            {
                userName = "AB+";
            }
            //check from database
            //List<User> list;
            myDatabaseEntities2 db1 = new myDatabaseEntities2();
            var list = (from x in db1.Users
                        where x.bloodGroup == userName
                        select new {n = x.name , b = x.bloodGroup , r = x.rollNumber }).ToList();
                return this.Json(list, JsonRequestBehavior.AllowGet);
            
        }
    }
}
