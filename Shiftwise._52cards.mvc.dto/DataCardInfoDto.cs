using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shiftwise._52cards.mvc.common.Enum;

namespace Shiftwise._52cards.mvc.dto
{
    public class DataCardInfoDto 
    {
        public DataCardInfoDto()
        {

        }
        public CardElementDTO[] CardElementDTOs { get; set; }
        public string Game { get; set; }

    }


    public class CardElementDTO 
    {
        public CardElementDTO()
        {

        }

        public string DeckId { get; set; }
        public Shiftwise._52cards.mvc.common.Enum.CardSuitEnum CardSuitEnum { get; set; }
        public short Value { get; set; }
    }

}