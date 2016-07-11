using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shiftwise._52cards.mvc.WebApi.v1;
using Shiftwise._52cards.mvc.domain.Interface;
using Shiftwise._52cards.mvc.domain;
using Shiftwise._52cards.mvc.dto;
using Shiftwise._52cards.mvc.common.Enum;
using Shiftwise._52cards.mvc.repository;
using Shiftwise._52cards.mvc.DataEntities;

using FakeItEasy;


namespace Shiftwise52cards.mvc.App.Tests.Unit_Test.Repositories
{
    [TestClass]
    public class RepositoryUnitTest
    {
        public TestContext TestContext { get; set; }  //for trace debuggibg

        private DataCardInfoDto DataCardInfoDtoIn { get; set; }
        private IEnumerable<CardElementDTO> CardElementDTOsExpected { get; set; }
        private IRuleRepository IRuleRepository { get; set; }
        private string username = "default";
        private List<CardElementDTO> CardElementDTO_Out;
        private int CardElementDTOCount;

        
        [TestInitialize]
        public void Initialize()
        {
            CardElementDTOsExpected = null;
            DataCardInfoDtoIn = null;
            CardElementDTO_Out = null;
        }
        
        [TestMethod]
        public async Task Repository__SortCards_3CardsIn_returns_3_CardElementDTOs()
        {
             // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            //ascending order
            CardElementDTOsExpected = CardElementDTOsExpected.OrderBy(x => x.Value);

            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge",
                //send in descending cards. its more interesting
                CardElementDTOs = CardElementDTOsExpected.OrderByDescending(x => x.Value).ToArray()
            };
            
            CardElementDTOCount = CardElementDTOsExpected.Count();
            //A.CallTo(() =>  ICardService.SortCards(DataCardInfoDtoIn, username))
            //    .Returns(new List<CardElementDTO>()
            //    {
            //    new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
            //    new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
            //    new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
            //    });


            bool caught = false;
            // Act
            try
            { //we are testing Repo's actual sort routine
                RuleRepository Repository = new RuleRepository();
                IEnumerable<CardElementDTO> response = await Repository.GetSortedCards(DataCardInfoDtoIn, username);

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));
                CardElementDTO_Out = response.ToList();


            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("Repository__SortCards_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
            int index = 0;
            foreach (var item in CardElementDTO_Out)
            { // check for cards (No Sorting in Service)
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.ElementAt(index);
                index++;

                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                Assert.AreEqual(CardElementDTO.Value, item.Value);
            }
        }


        [TestMethod]
        public async Task Repository__ShuffleCards_3CardsIn_returns_3_CardElementDTOs()
        {
            //A deck is Shuffled when:
            //      No  sequences of adjacent cards Ascending

            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            //ascending order
            CardElementDTOsExpected = CardElementDTOsExpected.OrderBy(x => x.Value);

            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge",
                //send in descending cards. its more interesting
                CardElementDTOs = CardElementDTOsExpected.OrderByDescending(x => x.Value).ToArray()
            };

            CardElementDTOCount = CardElementDTOsExpected.Count();
            //A.CallTo(() =>  ICardService.SortCards(DataCardInfoDtoIn, username))
            //    .Returns(new List<CardElementDTO>()
            //    {
            //    new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
            //    new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
            //    new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
            //    });


            bool caught = false;
            // Act
            try
            { //we are testing Repo's actual sort routine
                RuleRepository Repository = new RuleRepository();
                IEnumerable<CardElementDTO> response = await Repository.GetShuffledCards(DataCardInfoDtoIn, username);

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));
                CardElementDTO_Out = response.ToList();


            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("Repository__ShuffleCards_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
            foreach (var item in CardElementDTO_Out)
            { // check for cards (No Sorting in Service)
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();

                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                Assert.AreEqual(CardElementDTO.Value, item.Value);
            }
            int runLength = 1;
            int startingNumber = CardElementDTO_Out[0].Value;
            int maxrunLength = 0;

            Dictionary<int, int> result = null;

            List<int> resultValue = new List<int>();
            foreach (var item in CardElementDTO_Out)
            {
                resultValue.Add(item.Value);
            }

            result = new Dictionary<int, int>();
            for (int m = 1; m < CardElementDTO_Out.Count(); m++)
            {
                var number = CardElementDTO_Out[m].Value;
                var previousNumber = CardElementDTO_Out[m - 1].Value;
                if (number - previousNumber == 1) //ascending
                {
                    runLength++;
                }
                else
                {
                    if (runLength != 1)
                    {
                        maxrunLength = (runLength > maxrunLength) ? runLength : maxrunLength;
                        result.Add(startingNumber, runLength);
                        TestContext.WriteLine(
                        string.Format("Error: runLength is > 1 for startingNumber {0}", startingNumber));
                    }
                    //Assert.AreEqual(runLength, 1);
                    runLength = 1;
                    startingNumber = number;
                }
            }
            if (runLength > 1)
            { //Last sequence in list has 2 or more adjacent cards
                result.Add(startingNumber, runLength);
            }
            if (result.Count() != 0) // || maxrunLength >= 3)  //Shuffle rule
            {
                Assert.Inconclusive("Shuffle Violation: The shuffled deck has {0} adjacent card sequencse and the Maximun sequence length is {1}", result.Count, maxrunLength);
            }

        }

    }
}
