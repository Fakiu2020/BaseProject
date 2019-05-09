using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BaseProject.Application.Common.CreditCards.Commands.DeleteCreditCard;
using BaseProject.Application.Common.CreditCards.Queries.GetCreditCardsList;
using BaseProject.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApi.Controller
{
    public class CreditCardController : BaseController
    {
        /// <summary>
        /// Get credit cards from user logged.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("me")]
  
        [ProducesResponseType(typeof(IEnumerable<CreditCardLookupModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMyCreditCards([FromQuery] GetCreditCardListQuery query)
        {
            query.UserId = CurrentUser.Id;
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Delete credit card. It is a soft delete and delete the credit card on braintree
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCreditCardCommand { Id = id });
            return NoContent();
        }
    }
}
