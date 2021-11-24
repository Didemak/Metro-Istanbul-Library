using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryMVC.Tasks.Jobs
{
    public class CezaArtirmaDusurmeJob : IJob
    {
        OduncManager om = new OduncManager(new EfOduncDal());
        UyeManager um = new UyeManager(new EfUyeDal());
        public CezaArtirmaDusurmeJob()
        {

        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                CezaArttir();
                CezaDusur();
                //savechanges / unitOfWork.SaveChanges();
            }
            catch{ }
        }
        void CezaArttir()
        {
            var oduncKitaplar = om.GetOduncList().Where(x => x.TeslimEdilenTarih == null && DateTime.Now > x.TeslimEdilecekTarih);
            foreach(var oduncKitap in oduncKitaplar)
            {
                oduncKitap.Uye.Ceza += 1;
                um.UyeUpdate(oduncKitap.Uye);
            }
        }
        void CezaDusur()
        {
            var oduncKitaplar = om.GetOduncList().Where(x => x.TeslimEdilenTarih != null && x.Uye.Ceza>0);
            foreach (var oduncKitap in oduncKitaplar)
            {
                oduncKitap.Uye.Ceza -= 1;
                um.UyeUpdate(oduncKitap.Uye);
            }
        }
    }
}