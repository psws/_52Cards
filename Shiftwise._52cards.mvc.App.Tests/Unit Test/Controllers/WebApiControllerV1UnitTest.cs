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

using FakeItEasy;


namespace Shiftwise52cards.mvc.App.Tests.Unit_Test
{
    [TestClass]
    public class WebApiControllerV1UnitTest
    {
        public TestContext TestContext { get; set; }  //for trace debuggibg

        private DataCardInfoDto DataCardInfoDtoIn { get; set; }
        private IEnumerable<CardElementDTO> CardElementDTOsExpected { get; set; }
        private ICardService ICardService { get; set; }
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
        public async Task WebApi_52DataController_v1__SortCards__ActionResult_0CardsIn_returns_3_CardElementDTOs()
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
                Game = "Bridge"
            };
            

            ICardService = A.Fake<ICardService>();
            //var bar = await ICardService.SortCards(DataCardInfoDto, username); 
            A.CallTo(() => ICardService.SortCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

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
            {
                _52DataController controller = new _52DataController(ICardService);
                IHttpActionResult HttpActionResult = await controller.SortCards(DataCardInfoDtoIn);
                var response = HttpActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response.Content, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.Content.ToList();
                    //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("WebApi_52DataController_v1__SortCards__ActionResult_0CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
            int index = 0;
            foreach (var item in CardElementDTO_Out)
            { // check for cards (the Data Controller does no sorting)
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
        public async Task WebApi_52DataController_v1__SortCards_ActionResult_3CardsIn_returns_3_CardElementDTOs()
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
                CardElementDTOs = CardElementDTOsExpected.ToArray()
            };

            ICardService = A.Fake<ICardService>();

            A.CallTo(() => ICardService.SortCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = CardElementDTOsExpected.Count();


            bool caught = false;

            // Act
            try
            {
                _52DataController controller = new _52DataController(ICardService);
                IHttpActionResult HttpActionResult = await controller.SortCards(DataCardInfoDtoIn);
                var response = HttpActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response.Content, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.Content.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format("WebApi_52DataController_v1__SortCards_ActionResult_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
            int index = 0;
            foreach (var item in CardElementDTO_Out)
            { // check for cards (the Data Controller does no sorting)
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
        public async Task WebApi_52DataController_v1__ShuffleCards_ActionResult_0CardsIn_returns_0_CardElementDTOs()
        {
            // Arrange
            CardElementDTOsExpected = new List<CardElementDTO>()
            {
                //new CardElementDTO {DeckId= "Ace_Spade", Value=14, CardSuitEnum = CardSuitEnum.SPADE},
                //new CardElementDTO {DeckId= "King_Spade", Value=13, CardSuitEnum = CardSuitEnum.SPADE},
                //new CardElementDTO {DeckId= "Queen_Spade", Value=12, CardSuitEnum = CardSuitEnum.SPADE}
            };
            DataCardInfoDtoIn = new DataCardInfoDto()
            {
                Game = "Bridge"
            };


            ICardService = A.Fake<ICardService>();

            A.CallTo(() => ICardService.SortCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = CardElementDTOsExpected.Count();


            bool caught = false;

            // Act
            try
            {
                _52DataController controller = new _52DataController(ICardService);
                IHttpActionResult HttpActionResult = await controller.ShuffleCards(DataCardInfoDtoIn);
                var response = HttpActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response.Content, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.Content.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format(" WebApi_52DataController_v1__ShuffleCards_ActionResult_0CardsIn_returns_0_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(0, CardElementDTO_Out.Count); //no cards were submitted
            foreach (var item in CardElementDTO_Out)
            { // check for cards  No Shuffling in Data Controller
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                Assert.AreEqual(CardElementDTO.Value, item.Value);
            }

        }


        [TestMethod]
        public async Task WebApi_52DataController_v1__ShuffleCards_ActionResult_3CardsIn_returns_3_CardElementDTOs()
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


            ICardService = A.Fake<ICardService>();
            A.CallTo(() => ICardService.ShuffleCards(DataCardInfoDtoIn, username))
               .Returns(Task<IEnumerable<CardElementDTO>>.FromResult(CardElementDTOsExpected));

            CardElementDTOCount = CardElementDTOsExpected.Count();


            bool caught = false;

            // Act
            try
            {
                _52DataController controller = new _52DataController(ICardService);
                IHttpActionResult HttpActionResult = await controller.ShuffleCards(DataCardInfoDtoIn);
                var response = HttpActionResult as OkNegotiatedContentResult<IEnumerable<CardElementDTO>>;

                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response.Content, typeof(IEnumerable<CardElementDTO>));

                CardElementDTO_Out = response.Content.ToList();
                //throw new Exception();

            }
            catch (Exception ex)
            {
                TestContext.WriteLine(
                    string.Format(" WebApi_52DataController_v1__ShuffleCards_ActionResult_3CardsIn_returns_3_CardElementDTOs exception{0}",
                    ex.Message));
                caught = true;
            }

            // Assert
            Assert.IsFalse(caught);  //exception
            Assert.IsNotNull(CardElementDTO_Out);
            Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
            foreach (var item in CardElementDTO_Out)
            { // check for cards  No Shuffling in Data Controller
                //find DeckId in expected
                CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                Assert.IsNotNull(CardElementDTO);
                Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                Assert.AreEqual(CardElementDTO.Value, item.Value);
            }

        }


    }
}
