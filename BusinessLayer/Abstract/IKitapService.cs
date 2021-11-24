using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKitapService
    {
        List<Kitap> GetKitapList();
        void KitapAdd(Kitap kitap);
        Kitap GetByID(int id);
        void KitapDelete(Kitap kitap);
        void KitapUpdate(Kitap kitap);
        List<Kitap> KitapSearch(string kitapAdi);
    }
}