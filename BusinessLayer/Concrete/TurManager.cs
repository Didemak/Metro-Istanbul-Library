using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TurManager:ITurService
    {
        ITurDal _turDal; //bağımlılıkları minimize etmek. genericrepo'yu newlemeden oradaki değerlere erişebildik. 

        public TurManager(ITurDal turDal)
        {
            _turDal = turDal;
        }

        public Tur GetByID(int id)
        {
            return _turDal.Get(x => x.Id == id);
        }

        public List<Tur> GetTurList()
        {
            return _turDal.List();
        }

        public void TurAdd(Tur tur)
        {
            _turDal.Insert(tur);
        }

        public void TurDelete(Tur tur)
        {
            _turDal.Delete(tur);
        }

        public void TurUpdate(Tur tur)
        {
            _turDal.Update(tur);
        }
    }
}
