using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOduncService
    {
        List<Odunc> GetOduncList();
        void OduncAdd(Odunc odunc);
        Odunc GetByID(int id);
        void OduncDelete(Odunc odunc);
        void OduncUpdate(Odunc odunc);
    }
}
