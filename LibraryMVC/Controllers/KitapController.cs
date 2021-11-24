using BusinessLayer.Concreate;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace LibraryMVC.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KitapManager kitapmanager = new KitapManager(new EfKitapDal());
        TurManager tm = new TurManager(new EfTurDal());
        OduncManager om = new OduncManager(new EfOduncDal());

        public ActionResult GetKitapList(int sayfa=1)
        {
            var kitapvalues = kitapmanager.GetKitapList().ToPagedList(sayfa,4);
            return View(kitapvalues);
        }

        [HttpGet]
        public ActionResult AddKitap()
        {
            List<SelectListItem> dinamik_degerler = (from x2 in tm.GetTurList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x2.TurAdi,
                                                         Value = x2.Id.ToString()
                                                     }
                            ).ToList();
            ViewBag.degerlerim = dinamik_degerler;
            return View();
        }
        [HttpPost]
        public ActionResult AddKitap(Kitap entity)
        {
            //   kitapmanager.KitapEkleBL(entity);
            KitapValidator kitapValidator = new KitapValidator();
            ValidationResult results = kitapValidator.Validate(entity);
            if (results.IsValid)
            {
                entity.IsActive = true;
                kitapmanager.KitapAdd(entity);
                return RedirectToAction("GetKitapList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            List<SelectListItem> dinamik_degerler = (from x2 in tm.GetTurList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x2.TurAdi,
                                                         Value = x2.Id.ToString()
                                                     }
                           ).ToList();
            ViewBag.degerlerim = dinamik_degerler;
            return View();
        }
        public ActionResult DeleteKitap(int id)
        {
            var silinecek = kitapmanager.GetByID(id);
            var odunc = (from odun in om.GetOduncList()
                         where odun.Kitap.Id == id
                         select odun).FirstOrDefault();

            if (odunc == null && silinecek != null)
            {
                silinecek.IsActive = false;
            }
            else
            {
                silinecek.IsActive = false;
                odunc.IsActive = false;
                om.OduncUpdate(odunc);
            }
            kitapmanager.KitapUpdate(silinecek);
            return RedirectToAction("GetKitapList");
        }
        [HttpGet]
        public ActionResult EditKitap(int id)
        {
            List<SelectListItem> dinamik_degerler = (from x2 in tm.GetTurList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x2.TurAdi,
                                                         Value = x2.Id.ToString()
                                                     }
                ).ToList();
            ViewBag.degerlerim = dinamik_degerler;
            var kitap = kitapmanager.GetByID(id);
            return View(kitap);
        }
        [HttpPost]
        public ActionResult EditKitap(Kitap entity)
        {
            entity.IsActive = true;
            kitapmanager.KitapUpdate(entity);

            return RedirectToAction("GetKitapList");
        }

        [HttpPost]
        public ActionResult KitapAra(string kitapAdi)
        {
            var bulunanlar = kitapmanager.KitapSearch(kitapAdi).ToPagedList(1,4);
            return View("GetKitapList", bulunanlar);
        }

        public ActionResult GecmisListele()
        {
            var kitapvalues = kitapmanager.GetKitapList();
            return View(kitapvalues);
        }
        public ActionResult KitapGecmisSil(int id)
        {
            var kitap = kitapmanager.GetByID(id);
            kitapmanager.KitapDelete(kitap);
            return RedirectToAction("GecmisListele");
        }
    }
}