using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Odunc
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int KitapID { get; set; }
        public virtual Kitap Kitap { get; set; }
        public int UyeID { get; set; }
        public virtual Uye Uye { get; set; }
        public DateTime TeslimEdilecekTarih { get; set; }
        public DateTime? TeslimEdilenTarih { get; set; }
        public DateTime AlinanTarih { get; set; }

    }
}
