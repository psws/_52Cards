using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shiftwise._52cards.mvc.common.Enum;
using Shiftwise._52cards.mvc.dto;

namespace Shiftwise._52cards.mvc.repository
{
    public static class CardDeck
    {

        public static List<CardElementDTO> CardElementDTOBridgeList = new List<CardElementDTO>() {
                new CardElementDTO {DeckId= "Ace_Club", Value=14, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "King_Club", Value=13, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "Queen_Club", Value=12, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "Jack_Club", Value=11, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "10_Club", Value=10, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "9_Club", Value=9, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "8_Club", Value=8, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "7_Club", Value=7, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "6_Club", Value=6, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "5_Club", Value=5, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "4_Club", Value=4, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "3_Club", Value=3, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "2_Club", Value=2, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "Ace_Diamond", Value=27, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "King_Diamond", Value=26, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Queen_Diamond", Value=25, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Jack_Diamond", Value=24, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "10_Diamond", Value=23, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "9_Diamond", Value=22, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "8_Diamond", Value=21, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "7_Diamond", Value=20, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "6_Diamond", Value=19, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "5_Diamond", Value=18, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "4_Diamond", Value=17, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "3_Diamond", Value=16, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "2_Diamond", Value=15, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Ace_Heart", Value=40, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "King_Heart", Value=39, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Queen_Heart", Value=38, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Jack_Heart", Value=37, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "10_Heart", Value=36, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "9_Heart", Value=35, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "8_Heart", Value=34, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "7_Heart", Value=33, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "6_Heart", Value=32, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "5_Heart", Value=31, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "4_Heart", Value=30, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "3_Heart", Value=29, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "2_Heart", Value=28, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Ace_Spade", Value=54, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=53, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=52, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Jack_Spade", Value=50, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "10_Spade", Value=49, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "9_Spade", Value=48, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "8_Spade", Value=47, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "7_Spade", Value=46, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "6_Spade", Value=45, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "5_Spade", Value=44, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "4_Spade", Value=43, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "3_Spade", Value=42, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "2_Spade", Value=41, CardSuitEnum = CardSuitEnum.SPADE}
            };

        public static List<CardElementDTO> GetCardDeck(string Game)
        {
            List<CardElementDTO> CardElementDTOs = null;
            if (Game == "Bridge")
	        {
            //http://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c
                //clone list
                CardElementDTOs = new List<CardElementDTO>();

                foreach (var item in CardElementDTOBridgeList)
                {
                    CardElementDTO CardElementDTO = new CardElementDTO()
                    {
                        DeckId = item.DeckId,
                        CardSuitEnum = item.CardSuitEnum,
                        Value = item.Value
                    };
                    CardElementDTOs.Add(CardElementDTO);
                }
	        }
            return CardElementDTOs;
        }

    }
}