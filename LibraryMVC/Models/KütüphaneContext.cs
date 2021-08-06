using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public class KütüphaneContext : DbContext
    {
        public KütüphaneContext() : base("kütüphaneConnection")
        {
            Database.SetInitializer(new KütüphaneInitializer()); //benim tanımladığım initializerden haberi var
        }

        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Odunc> Oduncler { get; set; }
    }
}