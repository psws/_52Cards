using System;
using System.Collections.Generic;

namespace Shiftwise._52cards.mvc.DataEntities
{
    public partial class Deck : IEntity
    {
        public Deck()
        {
            this.Rules = new List<Rule>();
        }

        public string DeckId { get; set; }
        public int CardSuitEnum { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }

        public EntityState EntityState { get; set; }
    }
}
