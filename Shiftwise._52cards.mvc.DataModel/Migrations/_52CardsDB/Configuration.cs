namespace Shiftwise._52cards.mvc.DataModel.Migrations._52CardsDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shiftwise._52cards.mvc.DataModel._52CardsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\_52CardsDB";
        }

        protected override void Seed(Shiftwise._52cards.mvc.DataModel._52CardsDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            RuleSeeds.SeedContest(context);
            DeckSeeds.SeedContest(context);
        }
    }
}
