using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Shiftwise._52cards.mvc.DataEntities;
using Shiftwise._52cards.mvc.dto;
using Shiftwise._52cards.mvc.common.Enum;

namespace Shiftwise._52cards.mvc.repository
{
    public class RuleRepository : GenericDataRepository<Rule>, IRuleRepository
    {

        public async Task<IEnumerable<CardElementDTO>> GetSortedCards(DataCardInfoDto DataCardInfoDto, string username)
        {
            IEnumerable<CardElementDTO> CardElementDTOs = null;
            if (DataCardInfoDto.CardElementDTOs != null && DataCardInfoDto.CardElementDTOs.Length > 0)
            { //Sort deck in function Parameter
                CardElementDTOs = DataCardInfoDto.CardElementDTOs.OrderBy(x=>x.Value);
            }
            else
            {  //get deck from database
#if NoDB
                CardElementDTOs = CardDeck.GetCardDeck(DataCardInfoDto.Game);
                if (CardElementDTOs != null)
                {
                    CardElementDTOs = CardElementDTOs.OrderBy(x => x.Value).AsEnumerable();
                }
#else
               //using (var context = new ContestqsoDataEntities())
                //{
                //    IQueryable<Qso> QsoQuery = context.Set<Qso>().AsNoTracking();
                //    IQueryable<CallSign> CallSignQuery = context.Set<CallSign>().AsNoTracking();
                //    var Callsigns = (from lc in CallSignQuery
                //                     join lq in QsoQuery on lc.CallSignId equals lq.CallsignId
                //                     where lq.LogId == Logid
                //                     select lc).Distinct().ToList();
                //    return Callsigns;
                //}
#endif


            }
            return CardElementDTOs;
        }

        public async Task<IEnumerable<CardElementDTO>> GetShuffledCards(DataCardInfoDto DataCardInfoDto, string username)
        {
            //A deck is Shuffled when:
            //      No  sequences of adjacent cards Ascending
            bool bDone = false;
            IEnumerable<CardElementDTO> CardElementDTOs = null;
            if (DataCardInfoDto.CardElementDTOs != null && DataCardInfoDto.CardElementDTOs.Length > 0)
            { //Sort deck in function Parameter
                //The Shuffle
                while (bDone == false)
                {
                    
#if false
                    //https://blog.codinghorror.com/shuffling/
                    //CardElementDTOs = DataCardInfoDto.CardElementDTOs.OrderBy(a => Guid.NewGuid());
#else
                    //or Fisher-Yates
                    //http://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
                    Random rnd1 = new Random();
                    DataCardInfoDto.CardElementDTOs.Shuffle(rnd1);

                    Dictionary<int, int> resultDictionary = new Dictionary<int, int>();
                    int runLength = 1;
                    int startingNumber = DataCardInfoDto.CardElementDTOs[0].Value;
                    int maxrunLength = 0;

                    for (int m = 1; m < DataCardInfoDto.CardElementDTOs.Count(); m++)
                    {
                        var number = DataCardInfoDto.CardElementDTOs[m].Value;
                        var previousNumber = DataCardInfoDto.CardElementDTOs[m - 1].Value;
                        if (number - previousNumber == 1) //ascending
                        {
                            runLength++;
                        }
                        else
                        {
                            if (runLength != 1)
                            {
                                maxrunLength = (runLength > maxrunLength)?runLength : maxrunLength;  
                                resultDictionary.Add(startingNumber, runLength);
                            }

                            runLength = 1;
                            startingNumber = number;
                        }
                    }
                    if (runLength >1)
                    { //Last sequence in list has 2 or more adjacent cards
                        resultDictionary.Add(startingNumber, runLength);
                    }
                    if (resultDictionary.Count() == 0)  //Shuffle rule
                    {
                        bDone = true;
                    }

#endif
                }
                CardElementDTOs = new List<CardElementDTO>();
                CardElementDTOs = DataCardInfoDto.CardElementDTOs;
            }
            return CardElementDTOs;
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }

}