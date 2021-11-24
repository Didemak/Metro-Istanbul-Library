using BusinessLayer.Concreate;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        KitapManager kitapmanager = new KitapManager(new EfKitapDal());
        OduncManager om = new OduncManager(new EfOduncDal());
        UyeManager um = new UyeManager(new EfUyeDal());
        public ActionResult Index()
        {
            var sonBirHafta = DateTime.Now.AddDays(-6);
            ViewBag.kitapSayisi = kitapmanager.GetKitapList().Count(x => x.IsActive == true);
            ViewBag.uyeSayisi = um.GetUyeList().Count(x => x.IsActive == true);
            ViewBag.oduncSayisi = om.GetOduncList().Count(x => x.IsActive == true);
            ViewBag.iadeSayisi = om.GetOduncList().Count(x=>x.IsActive==false);
            return View();
        }
    }
}