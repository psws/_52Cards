using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

using Shiftwise._52cards.mvc.domain.Interface;
using Shiftwise._52cards.mvc.repository;
using Shiftwise._52cards.mvc.dto;

namespace Shiftwise._52cards.mvc.domain
{
    public class CardService : ICardService
    {
        private readonly IRuleRepository _RuleRepository;

        public CardService(IRuleRepository RuleRepository)
        {
            _RuleRepository = RuleRepository;

        }

        public async Task<IEnumerable<CardElementDTO>> SortCards(DataCardInfoDto DataCardInfoDto, string username)
        {
            var SortedCardElementDTO = await _RuleRepository.GetSortedCards(DataCardInfoDto, username);


             //return Task.FromResult(DataCallInfoDtos);
            return SortedCardElementDTO;
        }

        public async Task<IEnumerable<CardElementDTO>> ShuffleCards(DataCardInfoDto DataCardInfoDto, string username)
        {
            var SortedCardElementDTO = await _RuleRepository.GetShuffledCards(DataCardInfoDto, username);


            //return Task.FromResult(DataCallInfoDtos);
            return SortedCardElementDTO;
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