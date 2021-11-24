using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        UyeManager um = new UyeManager(new EfUyeDal());
        OduncManager om = new OduncManager(new EfOduncDal());
        Context c = new Context(); 
        [HttpGet]
        public ActionResult AddUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUye(Uye entity)
        {
            Uye _uye = (from uye in um.GetUyeList()
                             where uye.SicilNo == entity.SicilNo
                             select uye).FirstOrDefault();
            if (_uye == null)
            {
                entity.IsActive = true;
                //um.UyeAddBL(entity);
                UyeValidator uyeValidator = new UyeValidator();
                ValidationResult results = uyeValidator.Validate(entity);
                if (results.IsValid)
                {
                    um.UyeAdd(entity);
                    return RedirectToAction("GetUyeList");
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
            else
            {
                return RedirectToAction("AddUye");
            }
        }
        public ActionResult DeleteUye(int id)
        {
            var silinecek = um.GetByID(id);
            var odunc = (from odun in om.GetOduncList()
                         where odun.Uye.Id == id
                         select odun).FirstOrDefault();
            if (odunc == null && silinecek!=null)
            {
                silinecek.IsActive = false;
            }
            else
            {
                silinecek.IsActive = false;
                odunc.Kitap.StokDurumu += 1;
                odunc.IsActive = false;
                om.OduncUpdate(odunc);
            }

            //if (silinecek!=null)
            //{
            //    silinecek.IsActive = false;
            //}
            um.UyeUpdate(silinecek);

            //var uye = um.GetByID(id);
            //uye.IsActive = false;
            //c.SaveChanges();
            //return RedirectToAction("GetUyeList");
            /*var uye = um.GetByID(id);
            um.UyeDelete(uye);*/
            return RedirectToAction("GetUyeList");
        }
        [HttpGet]
        public ActionResult EditUye(int id)
        {
            var uye = um.GetByID(id);
            return View(uye);
        }
        [HttpPost]
        public ActionResult EditUye(Uye entity)
        {
            entity.IsActive = true;
            um.UyeUpdate(entity);

            return RedirectToAction("GetUyeList");
        }
        public ActionResult UyeAra(string uyeAdi)
        {
            var bulunanlar = um.UyeSearch(uyeAdi);
            return View("GetUyeList", bulunanlar);
        }
        public ActionResult GetUyeList()
        {
            var uyeler = um.GetUyeList();
            return View(uyeler);
        }

        public ActionResult GecmisListele()
        {
            var uyeler = um.GetUyeList();
            return View(uyeler);
        }
        public ActionResult UyeGecmisSil(int id)
        {
            var uye = um.GetByID(id);
            um.UyeDelete(uye);
            return RedirectToAction("GecmisListele");
        }
    }
}