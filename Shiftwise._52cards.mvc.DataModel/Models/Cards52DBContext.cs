using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Shiftwise._52cards.mvc.DataModel.Models.Mapping;
using Shiftwise._52cards.mvc.DataEntities;

namespace Shiftwise._52cards.mvc.DataModel.Models
{
    public partial class Cards52DBContext : DbContext
    {
        static Cards52DBContext()
        {
            Database.SetInitializer<Cards52DBContext>(null);

        }

        public Cards52DBContext()
        
#if SQL2012
            : base("Name=_52CardSQLExpress2012") {
#elif SQL2014
            : base("Name=_52CardSQLExpress2014") {
#else
            : base("Name=Cards52DBContext") {//No context needed, uses local list in Repo 
#endif  


                Configuration.LazyLoadingEnabled = false;
                Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Rule> Rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeckMap());
            modelBuilder.Configurations.Add(new RuleMap());
        }
    }
}
