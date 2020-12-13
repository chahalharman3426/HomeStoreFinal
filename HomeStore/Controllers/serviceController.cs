using HomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStore.Controllers
{
    public class serviceController : Controller
    {
        BuyHomeEntities buyHomeEntities = new BuyHomeEntities();

        // GET: Customer
        public ActionResult viewService()
        {
            return View(buyHomeEntities.ServiceDatas.ToList());
        }
        public ActionResult serviceList()
        {
            return View(buyHomeEntities.ServiceDatas.ToList());
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
        public ActionResult Create(ServiceData serviceData)
        {
            if (!ModelState.IsValid)
                return View();
            buyHomeEntities.ServiceDatas.Add(serviceData);
            buyHomeEntities.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("viewService");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var serviceID = (from m in buyHomeEntities.ServiceDatas where m.id == id select m).First();
            return View(serviceID);

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(ServiceData serviceData)
        {
            var orignalRecord = (from m in buyHomeEntities.ServiceDatas where m.id == serviceData.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            buyHomeEntities.Entry(orignalRecord).CurrentValues.SetValues(serviceData);
            buyHomeEntities.SaveChanges();
            return RedirectToAction("viewService");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(ServiceData serviceData)
        {
            var d = buyHomeEntities.ServiceDatas.Where(x => x.id == serviceData.id).FirstOrDefault();
            buyHomeEntities.ServiceDatas.Remove(d);
            buyHomeEntities.SaveChanges();
            return RedirectToAction("viewService");


        }



        // POST: service/Delete/5
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
