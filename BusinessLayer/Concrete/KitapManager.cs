using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class KitapManager : IKitapService
    {
        IKitapDal _kitapdal; //field

        public KitapManager(IKitapDal kitapdal)
        {
            _kitapdal = kitapdal;
        }

        public Kitap GetByID(int id)
        {
            return _kitapdal.Get(x => x.Id == id);
        }

        public List<Kitap> GetKitapList()
        {
            return _kitapdal.List();
        }

        public void KitapAdd(Kitap kitap)
        {
            _kitapdal.Insert(kitap);
        }

        public void KitapDelete(Kitap kitap)
        {
            _kitapdal.Delete(kitap);
        }

        public List<Kitap> KitapSearch(string kitapAdi)
        {
            return _kitapdal.List(x => x.KitapAdi.Contains(kitapAdi));
        }

        public void KitapUpdate(Kitap kitap)
        {
            _kitapdal.Update(kitap);
        }

    }
}