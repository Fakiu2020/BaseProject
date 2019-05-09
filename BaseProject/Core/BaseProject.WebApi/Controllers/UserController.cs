using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BaseProject.Application.Users.Commands.UpdateUser;
using BaseProject.Application.Users.Queries.GetAllUsers;
using BaseProject.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApi.Controller
{
    [Authorize]
    public class UserController : BaseController
    {
      
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserLookupModel>> GetAll([FromQuery] GetUserListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailModel>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetUserDetailQuery { Id = id }));
        }


        /// update user.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// delete user.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand {Id=id });
            return NoContent();
        }

    }
}
