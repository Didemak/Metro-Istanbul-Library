using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Tur
    {
        public int Id { get; set; }
        public string TurAdi { get; set; }

        public virtual List<Kitap> Kitaplar { get; set; }
    }
}
