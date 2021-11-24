using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUyeService
    {
        List<Uye> GetUyeList();
        void UyeAdd(Uye uye);
        Uye GetByID(int id);
        void UyeDelete(Uye uye);
        void UyeUpdate(Uye uye);
        List<Uye> UyeSearch(string uyeAdi);
    }
}
