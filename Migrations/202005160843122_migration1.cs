namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KursKayitlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GelenKisiSayisi = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Kurs_KursID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kurslars", t => t.Kurs_KursID)
                .Index(t => t.Kurs_KursID);
            
            CreateTable(
                "dbo.Kurslars",
                c => new
                    {
                        KursID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 50),
                        KursAd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KursID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KursKayitlars", "Kurs_KursID", "dbo.Kurslars");
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            DropTable("dbo.Kurslars");
            DropTable("dbo.KursKayitlars");
        }
    }
}
