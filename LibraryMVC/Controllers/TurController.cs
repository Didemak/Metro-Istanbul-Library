using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class TurController : Controller
    {
        // GET: Tur
        TurManager tm = new TurManager(new EfTurDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTurList()
        {
            var turler = tm.GetTurList();
            return View(turler);
        }
        [HttpGet]
        public ActionResult AddTur()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddTur(Tur entity)
        {

            TurValidator turValidator = new TurValidator();
            ValidationResult results = turValidator.Validate(entity);
            if (results.IsValid)
            {
                tm.TurAdd(entity);
                return RedirectToAction("GetTurList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //public ActionResult DeleteTur(int id)
        //{
        //    var tur = tm.GetByID(id);
        //    tm.TurDelete(tur);
        //    return RedirectToAction("GetTurList");
        //}
        [HttpGet]
        public ActionResult EditTur(int id)
        {
            var tur = tm.GetByID(id);
            return View(tur);
        }
        [HttpPost]
        public ActionResult EditTur(Tur entity)
        {
            
            tm.TurUpdate(entity);

            return RedirectToAction("GetTurList");
        }
    }
}