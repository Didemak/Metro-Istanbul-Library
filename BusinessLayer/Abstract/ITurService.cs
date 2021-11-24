using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITurService
    {
        List<Tur> GetTurList();
        void TurAdd(Tur tur);
        Tur GetByID(int id);
        void TurDelete(Tur tur);
        void TurUpdate(Tur tur);
    }
}
