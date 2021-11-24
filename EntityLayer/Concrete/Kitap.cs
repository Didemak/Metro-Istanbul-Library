using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string KitapYazari { get; set; }
        public string Aciklama { get; set; }
        public int BaskiYil { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string YayinEvi { get; set; }
        public int StokDurumu { get; set; }
        public bool IsActive { get; set; }
        public int TurID { get; set; }
        public virtual Tur Tur { get; set; }

    }
}
