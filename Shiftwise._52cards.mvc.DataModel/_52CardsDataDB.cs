using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace Shiftwise._52cards.mvc.DataModel
{
// https://msdn.microsoft.com/en-us/data/jj591621.aspx#model
    public class Cards52DB : DbContext
    {

        public Cards52DB()
            : base("name=_52CardSQLExpress2012")
        {
        }

        public DbSet<Shiftwise._52cards.mvc.DataModel.AnnotatedModels.Deck> Deck { get; set; }
        public DbSet<Shiftwise._52cards.mvc.DataModel.AnnotatedModels.Rule> Rule { get; set; }

        //public DbSet<Logqso.mvc.DataModel.LogData.CallInfoModels.CallInfoDefault> CallInfoDefault { get; set; }

        /* 
                   DeckSeeds.SeedContest(context);
                   RuleSeeds.SeedContest(context);

         * */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }

}
