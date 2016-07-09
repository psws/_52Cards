using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Threading.Tasks;

using Shiftwise._52cards.mvc.domain.Interface;
using Shiftwise._52cards.mvc.dto;

namespace Shiftwise._52cards.mvc.WebApi.v1
{
    [RoutePrefix("v1/Data")]
    public class _52DataController : ApiController
    {
        private readonly ICardService _CardService;
      
    #region Public constructor
        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>

        public _52DataController(ICardService CardService)
        {
            _CardService = CardService;
        }

    #endregion

        [HttpPost]
        [ResponseType(typeof(HttpResponseMessage))]
        [Route("SortCards")]
        public async Task<IHttpActionResult> SortCards(DataCardInfoDto DataCardInfoDto)
        {
            string Username = Shiftwise._52cards.mvc.common.definitions.Username;
            bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1)
            {
                Username = System.Web.HttpContext.Current.User.Identity.Name;
            }


            IEnumerable<CardElementDTO> SortedCardElementDTOs = null;

            SortedCardElementDTOs = await _CardService.SortCards(DataCardInfoDto, Username);


            if (SortedCardElementDTOs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SortedCardElementDTOs);
            }

        }

        [HttpPost]
        [ResponseType(typeof(HttpResponseMessage))]
        [Route("ShuffleCards")]
        public async Task<IHttpActionResult> ShuffleCards(DataCardInfoDto DataCardInfoDto)
        {
            string Username = Shiftwise._52cards.mvc.common.definitions.Username;
            bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1)
            {
                Username = System.Web.HttpContext.Current.User.Identity.Name;
            }


            IEnumerable<CardElementDTO> SortedCardElementDTOs = null;

            SortedCardElementDTOs = await _CardService.ShuffleCards(DataCardInfoDto, Username);


            if (SortedCardElementDTOs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SortedCardElementDTOs);
            }

        }



    }
}
