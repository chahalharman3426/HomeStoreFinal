using HomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStore.Controllers
{
    public class HomeController : Controller
    {

        BuyHomeEntities buyHomeEntities = new BuyHomeEntities();

        backEnd backEnd = new backEnd();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewFeedBack()
        {
            return View(buyHomeEntities.feedBacks.ToList());
        }

        public ActionResult gallery()
        {
            return View();
        }

        public ActionResult services()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        // GET: Customer/Delete/5
        public ActionResult Delete(feedBack feedbackID)
        {
            var d = buyHomeEntities.feedBacks.Where(x => x.feedbackID == feedbackID.feedbackID).FirstOrDefault();
            buyHomeEntities.feedBacks.Remove(d);
            buyHomeEntities.SaveChanges();
            return RedirectToAction("viewFeedBack");


        }



        public ActionResult done()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        public ActionResult sendMessage()
        {
            feedbackdetails feedbackdetails = new feedbackdetails();
            //generate the query to check the user name or passwod
            String qry = "insert into feedBack(Name,Email,Mobile,Subject,Message) values('" + feedbackdetails.Name + "','" + feedbackdetails.Email + "','" + feedbackdetails.Mobile + "','" + feedbackdetails.Subject + "','"+feedbackdetails.Message+"')";
            int x = backEnd.sendfeedBack(qry);
            if (x == 1)
            {
                return View("done");
            }
            else
            {
                return View();
            }



        }

    }
}