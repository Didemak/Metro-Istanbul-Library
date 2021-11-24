using BusinessLayer.Concreate;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryMVC.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        OduncManager om = new OduncManager(new EfOduncDal());
        KitapManager km = new KitapManager(new EfKitapDal());
        UyeManager um = new UyeManager(new EfUyeDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetOduncList()
        {
            var oduncler = om.GetOduncList();
            return View(oduncler);

        }
        [HttpGet]
        public ActionResult OduncVer(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(int Id, int SicilNo, DateTime teslimEdilecekTarih)
        {
            Kitap kitapId = (from kitap in km.GetKitapList()
                             where kitap.Id == Id
                             select kitap).FirstOrDefault();

            Uye sicilNo = (from uye in um.GetUyeList()
                         where uye.SicilNo == SicilNo
                         select uye).FirstOrDefault();
            //olmayan üyeye ödünç vermemek için alttaki kod eklendi
            if (sicilNo == null)
            {
                return RedirectToAction("GetKitapList", "Kitap");
            }
            kitapId.StokDurumu -= 1;
            //ustteki kod eklendi
            Odunc yeniodunc = new Odunc();
            yeniodunc.AlinanTarih = DateTime.Now;
            yeniodunc.TeslimEdilecekTarih = teslimEdilecekTarih;
            yeniodunc.KitapID = Id;
            yeniodunc.UyeID = sicilNo.Id;
            //yeniodunc.Kitap = kitapId;
            //yeniodunc.Uye = uyeId;
            yeniodunc.IsActive = true;


            om.OduncAdd(yeniodunc);
            km.KitapUpdate(kitapId);

            return RedirectToAction("GetOduncList");
        }

        public ActionResult KitapIade(int id)
        {
            var silinecek = om.GetByID(id);
            var artanStok = km.GetByID(silinecek.KitapID);
            artanStok.StokDurumu += 1;
            if (silinecek != null)
            {
                silinecek.IsActive = false;
            }
            silinecek.TeslimEdilenTarih = DateTime.Now;
            om.OduncUpdate(silinecek);
            km.KitapUpdate(artanStok);
            return RedirectToAction("GetOduncList");
        }

        public ActionResult GecmisListele()
        {
            var oduncler = om.GetOduncList();
            return View(oduncler);
        }
        public ActionResult OduncGecmisSil(int id)
        {
            var odunc = om.GetByID(id);
            om.OduncDelete(odunc);
            return RedirectToAction("GecmisListele");
        }
    }
}