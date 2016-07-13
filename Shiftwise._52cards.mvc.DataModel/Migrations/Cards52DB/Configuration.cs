namespace Shiftwise._52cards.mvc.DataModel.Migrations.Cards52DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shiftwise._52cards.mvc.DataModel.Cards52DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Cards52DB";
        }

        protected override void Seed(Shiftwise._52cards.mvc.DataModel.Cards52DB context)
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
            DeckSeeds.SeedContest(context);
            RuleSeeds.SeedContest(context);

        }
    }
}
