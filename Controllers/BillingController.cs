using Microsoft.AspNetCore.Mvc;
using HsptMS.Models;
using HsptMS.Services;
using System;

namespace HsptMS.Controllers
{
    public class BillingController : Controller
    {
        private static List<Billing> _billingList = Seed.SeedBilling();


        public ActionResult Index() 
        {
            return View(_billingList); 
        }

        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Billing billing)
        {
            billing.Id=GuidExtension.GetGuid();
             _billingList.Add(billing);
            return RedirectToAction("Index");
        }


        public ActionResult Details(Guid id)
        {
            var billing=_billingList.FirstOrDefault(x=> x.Id == id);
            return View(billing);   
        }

        public ActionResult Edit(Guid id) 
        {
            var billing=_billingList.FirstOrDefault(y=> y.Id == id);
            return View(billing);
        }
        [HttpPost]
        public ActionResult Edit(Billing billing)
        {
            var billings=_billingList.FirstOrDefault(x=>x.Id==billing.Id);
            _billingList.Remove(billings);
            _billingList.Add(billing);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var billing=_billingList.FirstOrDefault(x=>x.Id== id);
            return View(billing);
        }
        [HttpPost]
        public ActionResult Delete(Billing billing)
        {
            var billings = _billingList.FirstOrDefault(x=>x.Id==billing.Id);
            _billingList.Remove(billings);
            return RedirectToAction("Index");
        }
    }
}
