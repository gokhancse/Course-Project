namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miraton8 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.KursKayitlars", new[] { "Kurslar_KursID" });
            RenameColumn(table: "dbo.KursKayitlars", name: "Kurslar_KursID", newName: "KursId");
            AlterColumn("dbo.KursKayitlars", "KursId", c => c.Int(nullable: false));
            CreateIndex("dbo.KursKayitlars", "KursId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.KursKayitlars", new[] { "KursId" });
            AlterColumn("dbo.KursKayitlars", "KursId", c => c.Int());
            RenameColumn(table: "dbo.KursKayitlars", name: "KursId", newName: "Kurslar_KursID");
            CreateIndex("dbo.KursKayitlars", "Kurslar_KursID");
        }
    }
}
