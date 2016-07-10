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


namespace Shiftwise52cards.mvc.App.Tests.Unit_Test.Repositories
{
    [TestClass]
    public class WebApiControllerIntegrationTest
    {

        public TestContext TestContext { get; set; }  //for trace debuggibg

        private DataCardInfoDto DataCardInfoDtoIn { get; set; }
        private IEnumerable<CardElementDTO> CardElementDTOsExpected { get; set; }
        private IRuleRepository IRuleRepository { get; set; }
        private List<CardElementDTO> CardElementDTO_Out  { get; set; }
        private int CardElementDTOCount  { get; set; }
        private string Game  { get; set; }
        private bool insequence { get; set; }
      
        private ICardService ICardService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Game = "Bridge";
            CardElementDTOsExpected = CardDeck.GetCardDeck(Game);
            //make sure they are sorted desc
            CardElementDTOsExpected = CardElementDTOsExpected.OrderByDescending(x => x.Value).ToList();
            CardElementDTOCount = CardElementDTOsExpected.Count();
            insequence = false;
        }

        [TestMethod]
        public async Task Integration_WebApi_52DataController_v1__SortCards__ActionResult_0CardsIn_returns_52_CardElementDTOs()
        {
           using (IRuleRepository IRuleRepository = new RuleRepository())
           using (ICardService ICardService = new CardService(IRuleRepository))
           {
                //arrange
                DataCardInfoDtoIn = new DataCardInfoDto()
                {
                    Game = Game,
                };

                bool caught = false;

                // Act
#if NoDB
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
                        string.Format("Integration_WebApi_52DataController_v1__SortCards__ActionResult_0CardsIn_returns_52_CardElementDTOs exception{0}",
                        ex.Message));
                    caught = true;
                }

            // Assert
                Assert.IsFalse(caught);  //exception
                Assert.IsNotNull(CardElementDTO_Out);
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount);
               //check the deck intedrity
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x=>x.DeckId).Count());
                Assert.AreEqual(4, CardElementDTO_Out.DistinctBy(x => x.CardSuitEnum).Count());
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.Value).Count());

                //https://www.devtxt.com/blog/checking-whether-list-numbers-are-sequential-using-linq
               //does adeep compare
               insequence = CardElementDTO_Out.SequenceEqual(CardElementDTOsExpected);
                if (insequence == false)
                { //error
                    foreach (var item in CardElementDTO_Out)
                    { // check for cards (the Data Controller does no sorting)
                        //find DeckId in expected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();
                        
                        if (CardElementDTO == null)
	                    {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}",item.DeckId)  );
	                    }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                        Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                        Assert.AreEqual(item.Value, CardElementDTO.Value);
                    }
                }
#endif
            }
        }


        [TestMethod]
        public async Task Integration_WebApi_52DataController_v1__SortCards__ActionResult_52CardsIn_returns_52_CardElementDTOs()
        {
            using (IRuleRepository IRuleRepository = new RuleRepository())
            using (ICardService ICardService = new CardService(IRuleRepository))
            {
                //arrange
                DataCardInfoDtoIn = new DataCardInfoDto()
                {
                    Game = Game,
                    //in deck is ascending
                    CardElementDTOs = CardDeck.GetCardDeck(Game).OrderBy(x => x.DeckId).ToArray()
                };

                bool caught = false;

                // Act
#if NoDB
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
                        string.Format("Integration_WebApi_52DataController_v1__SortCards__ActionResult_52CardsIn_returns_52_CardElementDTOs exception{0}",
                        ex.Message));
                    caught = true;
                }

                // Assert
                Assert.IsFalse(caught);  //exception
                Assert.IsNotNull(CardElementDTO_Out);
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount);
                //check the deck intedrity
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.DeckId).Count());
                Assert.AreEqual(4, CardElementDTO_Out.DistinctBy(x => x.CardSuitEnum).Count());
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.Value).Count());
                //check first card
                Assert.AreEqual(CardElementDTO_Out[0].DeckId, "Ace_Spade");
                
                //https://www.devtxt.com/blog/checking-whether-list-numbers-are-sequential-using-linq
                //does adeep compare
                insequence = CardElementDTO_Out.SequenceEqual(CardElementDTOsExpected);
                if (insequence == false)
                { //error
                    foreach (var item in CardElementDTO_Out)
                    { // check for cards (the Data Controller does no sorting)
                        //find DeckId in expected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();

                        if (CardElementDTO == null)
                        {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}", item.DeckId));
                        }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                        Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                        Assert.AreEqual(item.Value, CardElementDTO.Value);
                    }
                }
#endif
            }
        }

        [TestMethod]
        public async Task Integration_WebApi_52DataController_v1__ShuffleCards__ActionResult_0CardsIn_returns_0_CardElementDTOs()
        {
            using (IRuleRepository IRuleRepository = new RuleRepository())
            using (ICardService ICardService = new CardService(IRuleRepository))
            {
                //arrange
                DataCardInfoDtoIn = new DataCardInfoDto()
                {
                    Game = Game,

                };

                bool caught = false;

                // Act
#if NoDB
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
                        string.Format("Integration_WebApi_52DataController_v1__SortCards__ActionResult_0CardsIn_returns_52_CardElementDTOs exception{0}",
                        ex.Message));
                    caught = true;
                }

                // Assert
                Assert.IsFalse(caught);  //exception
                Assert.IsNotNull(CardElementDTO_Out);
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTOCount);
                //check the deck intedrity
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.DeckId).Count());
                Assert.AreEqual(4, CardElementDTO_Out.DistinctBy(x => x.CardSuitEnum).Count());
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.Value).Count());

                //https://www.devtxt.com/blog/checking-whether-list-numbers-are-sequential-using-linq
                //does adeep compare
                insequence = CardElementDTO_Out.SequenceEqual(CardElementDTOsExpected);
                if (insequence == false)
                { //error
                    foreach (var item in CardElementDTO_Out)
                    { // check for cards (the Data Controller does no sorting)
                        //find DeckId in expected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();

                        if (CardElementDTO == null)
                        {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}", item.DeckId));
                        }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual(item.DeckId, CardElementDTO.DeckId);
                        Assert.AreEqual(item.CardSuitEnum, CardElementDTO.CardSuitEnum);
                        Assert.AreEqual(item.Value, CardElementDTO.Value);
                    }
                }
#endif
            }
        }

    }
}
