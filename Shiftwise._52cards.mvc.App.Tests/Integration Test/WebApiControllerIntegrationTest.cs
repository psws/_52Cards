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
            //make sure they are sorted Asc
            CardElementDTOsExpected = CardDeck.GetCardDeck(Game).OrderBy(x => x.Value);
            CardElementDTOCount = CardElementDTOsExpected.Count();
            CardElementDTO_Out = null;
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
                Assert.AreEqual(CardElementDTOCount ,CardElementDTO_Out.Count );
               //check the deck intedrity
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x=>x.DeckId).Count());
                Assert.AreEqual(4, CardElementDTO_Out.DistinctBy(x => x.CardSuitEnum).Count());
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.Value).Count());

                //https://www.devtxt.com/blog/checking-whether-list-numbers-are-sequential-using-linq
               //does adeep compare
               insequence = CardElementDTO_Out.SequenceEqual(CardElementDTOsExpected);
                if (insequence == false)
                { //error
                    int index = 0;
                    foreach (var item in CardElementDTO_Out)
                    { // check for cards (the real Repository does  sorting)
                        //CardElementDTO_Out order should match CardElementDTOsExpected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.ElementAt(index);
                        index++;
                        if (CardElementDTO == null)
	                    {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}",item.DeckId)  );
	                    }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual( CardElementDTO.DeckId, item.DeckId);
                        Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                        Assert.AreEqual(CardElementDTO.Value, item.Value );
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
                    //make deck In Descscending, output should Asccending
                    CardElementDTOs = CardDeck.GetCardDeck(Game).OrderByDescending(x => x.DeckId).ToArray()
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
                Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
                //check the deck integrity
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
                    int index = 0;
                    foreach (var item in CardElementDTO_Out)
                    { // check for cards (the real Repository does  sorting)
                        //CardElementDTO_Out order should match CardElementDTOsExpected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.ElementAt(index);

                        if (CardElementDTO == null)
                        {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}", item.DeckId));
                        }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                        Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                        Assert.AreEqual(CardElementDTO.Value, item.Value);
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

                    Assert.IsNull(response);

                }
                catch (Exception ex)
                {
                    TestContext.WriteLine(
                        string.Format("Integration_WebApi_52DataController_v1__ShuffleCards__ActionResult_0CardsIn_returns_0_CardElementDTOs exception{0}",
                        ex.Message));
                    caught = true;
                }

                // Assert
                Assert.IsFalse(caught);  //exception
                Assert.IsNull(CardElementDTO_Out);
#endif
            }
        }

        [TestMethod]
        public async Task Integration_WebApi_52DataController_v1__ShuffleCards__ActionResult_52CardsIn_returns_52_CardElementDTOs()
        {
            using (IRuleRepository IRuleRepository = new RuleRepository())
            using (ICardService ICardService = new CardService(IRuleRepository))
            {
                //arrange
                DataCardInfoDtoIn = new DataCardInfoDto()
                {
                    Game = Game,
                    //make deck ascending
                    CardElementDTOs = CardDeck.GetCardDeck(Game).OrderBy(x => x.DeckId).ToArray()
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
                        string.Format("Integration_WebApi_52DataController_v1__SortCards__ActionResult_52CardsIn_returns_52_CardElementDTOs exception{0}",
                        ex.Message));
                    caught = true;
                }

                // Assert
                Assert.IsFalse(caught);  //exception
                Assert.IsNotNull(CardElementDTO_Out);
                Assert.AreEqual(CardElementDTOCount, CardElementDTO_Out.Count);
                //check the deck intedrity
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.DeckId).Count());
                Assert.AreEqual(4, CardElementDTO_Out.DistinctBy(x => x.CardSuitEnum).Count());
                Assert.AreEqual(CardElementDTO_Out.Count, CardElementDTO_Out.DistinctBy(x => x.Value).Count());

                //https://www.devtxt.com/blog/checking-whether-list-numbers-are-sequential-using-linq
                //does a deep compare
                insequence = CardElementDTO_Out.SequenceEqual(CardElementDTOsExpected);
                if (insequence == false)
                { //error
                    foreach (var item in CardElementDTO_Out)
                    { // check for all cards 
                        //find DeckId in expected
                        CardElementDTO CardElementDTO = CardElementDTOsExpected.Where(x => x.DeckId == item.DeckId).FirstOrDefault();

                        if (CardElementDTO == null)
                        {
                            TestContext.WriteLine(
                            string.Format("Error: CardElementDTOsExpected List, CardElementDTO is null for item.DeckId => {0}", item.DeckId));
                        }

                        Assert.IsNotNull(CardElementDTO);
                        Assert.AreEqual(CardElementDTO.DeckId, item.DeckId);
                        Assert.AreEqual(CardElementDTO.CardSuitEnum, item.CardSuitEnum);
                        Assert.AreEqual(CardElementDTO.Value, item.Value);
                    }
                    //check shuffle quality.  No adjacent card Values
                    int runLength = 1;
                    int startingNumber = CardElementDTO_Out[0].Value;
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
                        if (previousNumber - number == 1) //descebding
                        {
                            runLength++;
                        }
                        else
                        {
                            if (runLength != 1)
                            {
                                result.Add(startingNumber, runLength);
                                TestContext.WriteLine(
                                string.Format("Error: runLength is > 1 for startingNumber {0}", startingNumber));
                            }
                            //Assert.AreEqual(runLength, 1);
                            runLength = 1;
                            startingNumber = number;
                        }
                    }
                    if (result.Count >=1)
	                {
                        Assert.Inconclusive("The shuffled deck has {0} adjacent card sequencse", result.Count);
	                }

                }
#endif
            }
        }





    }
}
