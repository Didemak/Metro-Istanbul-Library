using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UyeManager : IUyeService
    {
        IUyeDal _uyeDal; //bağımlılıkları minimize etmek. genericrepo'yu newlemeden oradaki değerlere erişebildik. 

        public UyeManager(IUyeDal uyeDal)
        {
            _uyeDal = uyeDal;
        }

        public Uye GetByID(int id)
        {
            return _uyeDal.Get(x=>x.Id==id);
        }

        public List<Uye> GetUyeList()
        {
            return _uyeDal.List();
        }

        public void UyeAdd(Uye uye)
        {
            _uyeDal.Insert(uye);
        }

        public void UyeDelete(Uye uye)
        {
            _uyeDal.Delete(uye);
        }

        public List<Uye> UyeSearch(string uyeAdi)
        {
            List<Uye> bulunanlar;
            if (uyeAdi.Contains(" "))
            {
                string[] AdSoyad = uyeAdi.Split(' ');
                string isim = AdSoyad[0];
                string soyisim = AdSoyad[1];

                bulunanlar = _uyeDal.List(x => x.UyeAdi.Contains(isim) && x.UyeSoyadi.Contains(soyisim));
            }
            else
            {
                bulunanlar = _uyeDal.List(x => x.UyeAdi.Contains(uyeAdi) || x.UyeSoyadi.Contains(uyeAdi));
            }
            return bulunanlar;
        }

        public void UyeUpdate(Uye uye)
        {
            _uyeDal.Update(uye);
        }
    }
}
