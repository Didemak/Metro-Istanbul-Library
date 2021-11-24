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
    public class OduncManager:IOduncService 
    {
        IOduncDal _oduncDal;
        public OduncManager(IOduncDal oduncDal)
        {
            _oduncDal = oduncDal;
        }

        public Odunc GetByID(int id)
        {
            return _oduncDal.Get(x => x.Id == id);
        }

        public List<Odunc> GetOduncList()
        {
            return _oduncDal.List();
        }

        public void OduncAdd(Odunc odunc)
        {
            _oduncDal.Insert(odunc);
        }

        public void OduncDelete(Odunc odunc)
        {
            _oduncDal.Delete(odunc);
        }

        public void OduncUpdate(Odunc odunc)
        {
            _oduncDal.Update(odunc);
        }
    }
}
