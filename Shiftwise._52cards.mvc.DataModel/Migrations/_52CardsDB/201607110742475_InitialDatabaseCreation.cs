namespace Shiftwise._52cards.mvc.DataModel.Migrations._52CardsDB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deck",
                c => new
                    {
                        DeckId = c.String(nullable: false, maxLength: 20, unicode: false),
                        CardSuitEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeckId);
            
            CreateTable(
                "dbo.Rule",
                c => new
                    {
                        DeckId = c.String(nullable: false, maxLength: 20, unicode: false),
                        GameName = c.String(nullable: false, maxLength: 35, unicode: false),
                        value = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeckId, t.GameName })
                .ForeignKey("dbo.Deck", t => t.DeckId, cascadeDelete: true)
                .Index(t => t.DeckId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rule", "DeckId", "dbo.Deck");
            DropIndex("dbo.Rule", new[] { "DeckId" });
            DropTable("dbo.Rule");
            DropTable("dbo.Deck");
        }
    }
}
