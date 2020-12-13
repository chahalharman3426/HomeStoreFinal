using HomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStore.Controllers
{
    public class CustomerController : Controller
    {

        BuyHomeEntities buyHomeEntities = new BuyHomeEntities();

        // GET: Customer
        public ActionResult viewCustomer()
        {
            return View(buyHomeEntities.Customers.ToList());
        }
        public ActionResult happyCustomer()
        {
            return View(buyHomeEntities.Customers.ToList());
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return View();
            buyHomeEntities.Customers.Add(customer);
            buyHomeEntities.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("viewCustomer");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customerID = (from m in buyHomeEntities.Customers where m.id == id select m).First();
            return View(customerID);

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customerID)
        {
            var orignalRecord = (from m in buyHomeEntities.Customers where m.id == customerID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            buyHomeEntities.Entry(orignalRecord).CurrentValues.SetValues(customerID);
            buyHomeEntities.SaveChanges();
            return RedirectToAction("viewCustomer");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(Customer customerID)
        {
            var d = buyHomeEntities.Customers.Where(x => x.id == customerID.id).FirstOrDefault();
            buyHomeEntities.Customers.Remove(d);
            buyHomeEntities.SaveChanges();
            return RedirectToAction("viewCustomer");

            
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
