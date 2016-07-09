using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Shiftwise._52cards.mvc.dto;
using Shiftwise._52cards.mvc.DataEntities;

namespace Shiftwise._52cards.mvc.repository
{
    public interface IRuleRepository : IGenericDataRepository<Rule>
    {
        Task<IEnumerable<CardElementDTO>> GetSortedCards(DataCardInfoDto DataCardInfoDto, string username);
        Task<IEnumerable<CardElementDTO>> GetShuffledCards(DataCardInfoDto DataCardInfoDto, string username);

    }
}
