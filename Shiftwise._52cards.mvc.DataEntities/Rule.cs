using System;
using System.Collections.Generic;

namespace Shiftwise._52cards.mvc.DataEntities
{
    public partial class Rule : IEntity
    {
        public string DeckId { get; set; }
        public string GameName { get; set; }
        public short Value { get; set; }
        public virtual Deck Deck { get; set; }

        public EntityState EntityState { get; set; }
    }
}
