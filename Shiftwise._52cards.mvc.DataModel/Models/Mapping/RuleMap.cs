using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Shiftwise._52cards.mvc.DataEntities;


namespace Shiftwise._52cards.mvc.DataModel.Models.Mapping
{
    public class RuleMap : EntityTypeConfiguration<Rule>
    {
        public RuleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DeckId, t.GameName });

            // Properties
            this.Property(t => t.DeckId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.GameName)
                .IsRequired()
                .HasMaxLength(35);

            // Table & Column Mappings
            this.ToTable("Rule");
            this.Property(t => t.DeckId).HasColumnName("DeckId");
            this.Property(t => t.GameName).HasColumnName("GameName");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.Deck)
                .WithMany(t => t.Rules)
                .HasForeignKey(d => d.DeckId);

        }
    }
}
