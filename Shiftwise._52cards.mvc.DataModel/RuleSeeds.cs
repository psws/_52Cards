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
    public class RuleSeeds
    {
        //  add to configuration.cs          RuleSeeds.SeedContest(context);

        public static void SeedContest(Shiftwise._52cards.mvc.DataModel.Cards52DB context)
        {

            context.Rule.AddOrUpdate(
            p => p.DeckId,
                new Rule { DeckId = "Ace_Club", Value = 14, GameName = "Bridge" },
                new Rule { DeckId = "King_Club", Value = 13, GameName = "Bridge" },
                new Rule { DeckId = "Queen_Club", Value = 12, GameName = "Bridge" },
                new Rule { DeckId = "Jack_Club", Value = 11, GameName = "Bridge" },
                new Rule { DeckId = "10_Club", Value = 10, GameName = "Bridge" },
                new Rule { DeckId = "9_Club", Value = 9, GameName = "Bridge" },
                new Rule { DeckId = "8_Club", Value = 8, GameName = "Bridge" },
                new Rule { DeckId = "7_Club", Value = 7, GameName = "Bridge" },
                new Rule { DeckId = "6_Club", Value = 6, GameName = "Bridge" },
                new Rule { DeckId = "5_Club", Value = 5, GameName = "Bridge" },
                new Rule { DeckId = "4_Club", Value = 4, GameName = "Bridge" },
                new Rule { DeckId = "3_Club", Value = 3, GameName = "Bridge" },
                new Rule { DeckId = "2_Club", Value = 2, GameName = "Bridge" },
                new Rule { DeckId = "Ace_Diamond", Value = 27, GameName = "Bridge" },
                new Rule { DeckId = "King_Diamond", Value = 26, GameName = "Bridge" },
                new Rule { DeckId = "Queen_Diamond", Value = 25, GameName = "Bridge" },
                new Rule { DeckId = "Jack_Diamond", Value = 24, GameName = "Bridge" },
                new Rule { DeckId = "10_Diamond", Value = 23, GameName = "Bridge" },
                new Rule { DeckId = "9_Diamond", Value = 22, GameName = "Bridge" },
                new Rule { DeckId = "8_Diamond", Value = 21, GameName = "Bridge" },
                new Rule { DeckId = "7_Diamond", Value = 20, GameName = "Bridge" },
                new Rule { DeckId = "6_Diamond", Value = 19, GameName = "Bridge" },
                new Rule { DeckId = "5_Diamond", Value = 18, GameName = "Bridge" },
                new Rule { DeckId = "4_Diamond", Value = 17, GameName = "Bridge" },
                new Rule { DeckId = "3_Diamond", Value = 16, GameName = "Bridge" },
                new Rule { DeckId = "2_Diamond", Value = 15, GameName = "Bridge" },
                new Rule { DeckId = "Ace_Heart", Value = 40, GameName = "Bridge" },
                new Rule { DeckId = "King_Heart", Value = 39, GameName = "Bridge" },
                new Rule { DeckId = "Queen_Heart", Value = 38, GameName = "Bridge" },
                new Rule { DeckId = "Jack_Heart", Value = 37, GameName = "Bridge" },
                new Rule { DeckId = "10_Heart", Value = 36, GameName = "Bridge" },
                new Rule { DeckId = "9_Heart", Value = 35, GameName = "Bridge" },
                new Rule { DeckId = "8_Heart", Value = 34, GameName = "Bridge" },
                new Rule { DeckId = "7_Heart", Value = 33, GameName = "Bridge" },
                new Rule { DeckId = "6_Heart", Value = 32, GameName = "Bridge" },
                new Rule { DeckId = "5_Heart", Value = 31, GameName = "Bridge" },
                new Rule { DeckId = "4_Heart", Value = 30, GameName = "Bridge" },
                new Rule { DeckId = "3_Heart", Value = 29, GameName = "Bridge" },
                new Rule { DeckId = "2_Heart", Value = 28, GameName = "Bridge" },
                new Rule { DeckId = "Ace_Spade", Value = 54, GameName = "Bridge" },
                new Rule { DeckId = "King_Spade", Value = 53, GameName = "Bridge" },
                new Rule { DeckId = "Queen_Spade", Value = 52, GameName = "Bridge" },
                new Rule { DeckId = "Jack_Spade", Value = 50, GameName = "Bridge" },
                new Rule { DeckId = "10_Spade", Value = 49, GameName = "Bridge" },
                new Rule { DeckId = "9_Spade", Value = 48, GameName = "Bridge" },
                new Rule { DeckId = "8_Spade", Value = 47, GameName = "Bridge" },
                new Rule { DeckId = "7_Spade", Value = 46, GameName = "Bridge" },
                new Rule { DeckId = "6_Spade", Value = 45, GameName = "Bridge" },
                new Rule { DeckId = "5_Spade", Value = 44, GameName = "Bridge" },
                new Rule { DeckId = "4_Spade", Value = 43, GameName = "Bridge" },
                new Rule { DeckId = "3_Spade", Value = 42, GameName = "Bridge" },
                new Rule { DeckId = "2_Spade", Value = 41, GameName = "Bridge" }
            );
        }
    }
}

