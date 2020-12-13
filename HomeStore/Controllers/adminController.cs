using HomeStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStore.Controllers
{
    public class adminController : Controller
    {
        backEnd backEnd = new backEnd();
        // GET: admin
        public ActionResult adminLogin()
        {
            return View();
        }

        public ActionResult adminPannel()
        {
            return View();
        }
        public ActionResult verification()
        {
            return View();
        }


        [HttpPost]
        public ActionResult authenticateUser(LoginClass Login_Block)
        {
            //generate the query to check the user name or passwod
            String qry = "select * from backendLogin where adminID='" + Login_Block.adminID + "' and adminPassword='" + Login_Block.adminPassword + "'";
            DataTable tbl = new DataTable();

            int x = backEnd.checkAdmin(qry);
            if (x > 0)
            {
                return View("adminPannel");
            }
            else
            {
                return View("verification");
            }


        }


    }
}