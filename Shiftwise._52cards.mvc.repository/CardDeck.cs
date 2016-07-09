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

        static List<CardElementDTO> CardElementDTOBridgeList = new List<CardElementDTO>() {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Jack_Spade", Value=11, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "10_Spade", Value=10, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "9_Spade", Value=9, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "8_Spade", Value=8, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "7_Spade", Value=7, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "6_Spade", Value=6, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "5_Spade", Value=5, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "4_Spade", Value=4, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "3_Spade", Value=3, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "2_Spade", Value=2, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Ace_Diamond", Value=34, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "King_Diamond", Value=33, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Queen_Diamond", Value=32, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Jack_Diamond", Value=31, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "10_Diamond", Value=30, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "9_Diamond", Value=29, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "8_Diamond", Value=28, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "7_Diamond", Value=27, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "6_Diamond", Value=26, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "5_Diamond", Value=25, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "4_Diamond", Value=24, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "3_Diamond", Value=23, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "2_Diamond", Value=22, CardSuitEnum = CardSuitEnum.DIAMOND},
                new CardElementDTO {DeckId= "Ace_Heart", Value=54, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "King_Heart", Value=53, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Queen_Heart", Value=52, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Jack_Heart", Value=51, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "10_Heart", Value=50, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "9_Heart", Value=49, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "8_Heart", Value=48, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "7_Heart", Value=47, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "6_Heart", Value=46, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "5_Heart", Value=45, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "4_Heart", Value=44, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "3_Heart", Value=43, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "2_Heart", Value=42, CardSuitEnum = CardSuitEnum.HEART},
                new CardElementDTO {DeckId= "Ace_Club", Value=74, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "King_Club", Value=73, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "Queen_Club", Value=72, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "Jack_Club", Value=71, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "10_Club", Value=70, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "9_Club", Value=69, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "8_Club", Value=68, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "7_Club", Value=67, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "6_Club", Value=66, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "5_Club", Value=65, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "4_Club", Value=64, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "3_Club", Value=63, CardSuitEnum = CardSuitEnum.CLUB},
                new CardElementDTO {DeckId= "2_Club", Value=62, CardSuitEnum = CardSuitEnum.CLUB}
            };

        public static List<CardElementDTO> GetCardDeck(string Game)
        {
            List<CardElementDTO> CardElementDTOs = null;
            if (Game == "Bridge")
	        {
		        CardElementDTOs = CardElementDTOBridgeList;
	        }
            return CardElementDTOs;
        }

    }
}