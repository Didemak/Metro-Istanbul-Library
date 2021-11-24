namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KitapAdi = c.String(),
                        KitapYazari = c.String(),
                        Aciklama = c.String(),
                        BaskiYil = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        YayinEvi = c.String(),
                        StokDurumu = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TurID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turs", t => t.TurID, cascadeDelete: true)
                .Index(t => t.TurID);
            
            CreateTable(
                "dbo.Turs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TurAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oduncs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        KitapID = c.Int(nullable: false),
                        UyeID = c.Int(nullable: false),
                        TeslimEdilecekTarih = c.DateTime(nullable: false),
                        TeslimEdilenTarih = c.DateTime(),
                        AlinanTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kitaps", t => t.KitapID, cascadeDelete: true)
                .ForeignKey("dbo.Uyes", t => t.UyeID, cascadeDelete: true)
                .Index(t => t.KitapID)
                .Index(t => t.UyeID);
            
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SicilNo = c.Int(nullable: false),
                        UyeAdi = c.String(),
                        UyeSoyadi = c.String(),
                        TelefonNo = c.String(),
                        Cinsiyet = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Ceza = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YetkiliGiris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SicilNo = c.Int(nullable: false),
                        sifre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oduncs", "UyeID", "dbo.Uyes");
            DropForeignKey("dbo.Oduncs", "KitapID", "dbo.Kitaps");
            DropForeignKey("dbo.Kitaps", "TurID", "dbo.Turs");
            DropIndex("dbo.Oduncs", new[] { "UyeID" });
            DropIndex("dbo.Oduncs", new[] { "KitapID" });
            DropIndex("dbo.Kitaps", new[] { "TurID" });
            DropTable("dbo.YetkiliGiris");
            DropTable("dbo.Uyes");
            DropTable("dbo.Oduncs");
            DropTable("dbo.Turs");
            DropTable("dbo.Kitaps");
        }
    }
}
