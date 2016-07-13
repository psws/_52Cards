using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiftwise._52cards.mvc.common.Enum;
using Shiftwise._52cards.mvc.DataModel.AnnotatedModels;

namespace Shiftwise._52cards.mvc.DataModel
{
    public class DeckSeeds
    {
        //  add to configuration.cs          DeckSeeds.SeedContest(context);

        public static void SeedContest(Shiftwise._52cards.mvc.DataModel.Cards52DB context)
        {

            context.Deck.AddOrUpdate(
            p => p.DeckId,
                new Deck { DeckId = "Ace_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "King_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "Queen_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "Jack_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "10_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "9_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "8_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "7_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "6_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "5_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "4_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "3_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "2_Club", CardSuitEnum = CardSuitEnum.CLUB },
                new Deck { DeckId = "Ace_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "King_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "Queen_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "Jack_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "10_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "9_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "8_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "7_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "6_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "5_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "4_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "3_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "2_Diamond", CardSuitEnum = CardSuitEnum.DIAMOND },
                new Deck { DeckId = "Ace_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "King_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "Queen_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "Jack_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "10_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "9_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "8_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "7_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "6_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "5_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "4_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "3_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "2_Heart", CardSuitEnum = CardSuitEnum.HEART },
                new Deck { DeckId = "Ace_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "King_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "Queen_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "Jack_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "10_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "9_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "8_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "7_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "6_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "5_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "4_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "3_Spade", CardSuitEnum = CardSuitEnum.SPADE },
                new Deck { DeckId = "2_Spade", CardSuitEnum = CardSuitEnum.SPADE }
              );
        }
    }
}
