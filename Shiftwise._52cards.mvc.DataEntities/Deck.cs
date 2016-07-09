using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shiftwise._52cards.mvc.common.Enum;

namespace Shiftwise._52cards.mvc.DataEntities
{
    public class Deck : IEntity
    {
        public Deck()
        {
        }

        public string DeckId { get; set; }
        public Shiftwise._52cards.mvc.common.Enum.CardSuitEnum CardSuitEnum { get; set; }
        public EntityState EntityState { get; set; }


    }
}