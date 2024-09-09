using Microsoft.AspNetCore.Mvc;
using HsptMS.Data.Models;
using HsptMS.Services;
using System;
using HMS.Data.Extensions;

namespace HsptMS.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingService _billingService;
        private readonly HmsContext _hmscontext;
        public BillingController(IBillingService billingService, HmsContext hmscontext) 
        {
            _billingService = billingService;
            _hmscontext = hmscontext;
        }
        public ActionResult Index() 
        {
            var displaay= _billingService.GetBillingList();
            return View(displaay); 
        }

        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Billing billing)
        {
            billing.Id=GuidExtension.GetGuid();
             _billingService.AddBilling(billing);
            return RedirectToAction("Index");
        }


        public ActionResult Details(Guid id)
        {
            var billing = _billingService.GetBillingById(id);
            return View(billing);   
        }

        public ActionResult Edit(Guid id) 
        {
            var billing=_billingService.GetBillingById(id);
            return View(billing);
        }
        [HttpPost]
        public ActionResult Edit(Billing billing)
        {
            var billings=_billingService.GetBillingById(billing.Id);
            _billingService.RemoveBillingById(billings.Id);
            _billingService.AddBilling(billing);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var billing=_billingService.GetBillingById(id);
            return View(billing);
        }
        [HttpPost]
        public ActionResult Delete(Billing billing)
        {
            var billings = _billingService.GetBillingById(billing.Id);
            _billingService.RemoveBillingById(billing.Id);
            return RedirectToAction("Index");
        }
    }
}
