using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProj.Models;

namespace MvcProj.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Home/
        ISignInRepository isr;

        public MainController(ISignInRepository isr1)
        {
            isr = isr1;
        }
        public ActionResult main()
        {
            return View();
        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult verifySignIn(User u)
        {
            if (isr.verifier(u))
            {
                Session["uroll"] = u.rollNumber;
                return RedirectToAction("home", "Home");
            }
            else
            {
                return RedirectToAction("main");
            }
        }
        [HttpPost]
        public ActionResult saveSignUp(User u)
        {
            u.bloodGroup = Request["bloodGroup"];
            HttpPostedFileBase file = Request.Files["InputFile"];
            file.SaveAs(Server.MapPath(@"~\Files\" + file.FileName));
            u.imagePath = @"~\Files\" + u.rollNumber;

            if (u.name != null && u.rollNumber != null && u.password != null && u.bloodGroup != null)
            {
                if(isr.saveSignUp(u))
                { 
                    return RedirectToAction("main", "Main");
                }
                else
                {
                    return RedirectToAction("signUp", "Main");
                }
            }
            else
            {
                return RedirectToAction("signUp","Main");
            }
        }
            
    }
}
