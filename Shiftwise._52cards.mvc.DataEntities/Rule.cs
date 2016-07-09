using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shiftwise._52cards.mvc.DataEntities
{
    public partial class Rule : IEntity
    {
        public Rule()
        {
            this.Deck = new List<Deck>();
        }

        public string DeckId { get; set; }
        public string GameName { get; set; }
        public short value { get; set; }
        public EntityState EntityState { get; set; }


        public virtual ICollection<Deck> Deck { get; set; }
    }
}