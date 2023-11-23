using DuAnQuanLyBatDongSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuAnQuanLyBatDongSan.Controllers
{
    public class ContractsController : Controller
    {
        private QUANLYBDS_17Entities1 db = new QUANLYBDS_17Entities1();
        // GET: Contracts
        public ActionResult Index()
        {
            var items = db.Full_Contract.OrderByDescending(x=>x.ID).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.Property = new SelectList(db.Properties.ToList(), "ID", "Property_Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Full_Contract model)
        {
            if (ModelState.IsValid)
            {
                model.Date_Of_Contract = DateTime.Now;
                //model.ModifiedDate = DateTime.Now;
                //model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Full_Contract.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Full_Contract.Find(id);
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.Full_Contract.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


    }
}