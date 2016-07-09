using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiftwise._52cards.mvc.repository;
using Shiftwise._52cards.mvc.dto;

namespace Shiftwise._52cards.mvc.domain.Interface
{
    public interface ICardService
    {

        Task<IEnumerable<CardElementDTO>> SortCards(DataCardInfoDto DataCardInfoDto, string username);
        Task<IEnumerable<CardElementDTO>> ShuffleCards(DataCardInfoDto DataCardInfoDto, string username);
    }
}
