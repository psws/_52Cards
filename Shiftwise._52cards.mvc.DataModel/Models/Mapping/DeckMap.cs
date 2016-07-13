using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shiftwise._52cards.mvc.DataEntities;

namespace Shiftwise._52cards.mvc.DataModel.Models.Mapping
{
    public class DeckMap : EntityTypeConfiguration<Deck>
    {
        public DeckMap()
        {
            // Primary Key
            this.HasKey(t => t.DeckId);

            // Properties
            this.Property(t => t.DeckId)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Deck");
            this.Property(t => t.DeckId).HasColumnName("DeckId");
            this.Property(t => t.CardSuitEnum).HasColumnName("CardSuitEnum");
        }
    }
}
