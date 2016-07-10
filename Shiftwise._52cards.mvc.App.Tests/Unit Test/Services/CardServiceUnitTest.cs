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


namespace Shiftwise52cards.mvc.App.Tests.Unit_Test.Services
{
    [TestClass]
    public class CardServiceUnitTest
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
        public async Task CardService__SortCards_0CardsIn_returns_3_CardElementDTOs()
        {
            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            
            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge"
            };


            IRuleRepository = A.Fake<IRuleRepository>();

            A.CallTo(() => IRuleRepository.GetSortedCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = (CardElementDTOsExpected as List<CardElementDTO>).Count;
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
            {
                CardService service = new CardService(IRuleRepository);
                IEnumerable<CardElementDTO> response = await service.SortCards(DataCardInfoDtoIn, username);
                //var response = ActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.ToList();

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("CardService__SortCards_0CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount);
            foreach (var item in CardElementDTO_Out)
            { // check for cards (No Sorting in Service)
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                Assert.AreEqual(item.Value, CardElementDTO.Value);
            }

        }



        [TestMethod]
        public async Task CardService__SortCards_3CardsIn_returns_3_CardElementDTOs()
        {
            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge",
                CardElementDTOs = CardElementDTOsExpected.ToArray()
            };


            IRuleRepository = A.Fake<IRuleRepository>();

            A.CallTo(() => IRuleRepository.GetSortedCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = (CardElementDTOsExpected as List<CardElementDTO>).Count;


            bool caught = false;

            // Act
            try
            {
                CardService service = new CardService(IRuleRepository);
                IEnumerable<CardElementDTO> response = await service.SortCards(DataCardInfoDtoIn, username);
                //var response = ActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("CardService__SortCards_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount);
            foreach (var item in CardElementDTO_Out)
            { // check for cards (No Sorting in Service)
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                Assert.AreEqual(item.Value, CardElementDTO.Value);
            }

        }


        [TestMethod]
        public async Task CardService__ShuffleCards_0CardsIn_returns_0_CardElementDTOs()
        {
            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                //new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                //new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                //new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge"
            };


            IRuleRepository = A.Fake<IRuleRepository>();
            //var bar = await ICardService.SortCards(DataCardInfoDto, username); 
            A.CallTo(() => IRuleRepository.GetShuffledCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = (CardElementDTOsExpected as List<CardElementDTO>).Count;


            bool caught = false;

            // Act
            try
            {
                CardService service = new CardService(IRuleRepository);
                IEnumerable<CardElementDTO> response = await service.ShuffleCards(DataCardInfoDtoIn, username);
                //var response = ActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("CardService__ShuffleCards_0CardsIn_returns_0_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTO_Out.Count, 0); //no cards were submitted
            foreach (var item in CardElementDTO_Out)
            { // check for cards  No Shuffling in Service
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                Assert.AreEqual(item.Value, CardElementDTO.Value);
            }

        }



        [TestMethod]
        public async Task CardService__ShuffleCards_3CardsIn_returns_3_CardElementDTOs()
        {
            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
                {
                new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE},
                };
            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge",
                CardElementDTOs = CardElementDTOsExpected.ToArray()
            };


            IRuleRepository = A.Fake<IRuleRepository>();
            //var bar = await ICardService.SortCards(DataCardInfoDto, username); 
            A.CallTo(() => IRuleRepository.GetShuffledCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = DataCardInfoDtoIn.CardElementDTOs.Count();


            bool caught = false;

            // Act
            try
            {
                CardService service = new CardService(IRuleRepository);
                IEnumerable<CardElementDTO> response = await service.ShuffleCards(DataCardInfoDtoIn, username);
                //var response = ActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("CardService__ShuffleCards_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount); //no cards were submitted
            foreach (var item in CardElementDTO_Out)
            { // check for cards  No Shuffling in Service
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                Assert.AreEqual(item.Value, CardElementDTO.Value);
            }

        }



    }
}
