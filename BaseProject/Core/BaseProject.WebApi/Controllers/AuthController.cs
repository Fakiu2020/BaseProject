using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BaseProject.Application.Auth.Commands.Login;
using BaseProject.Application.Users.CreateUser;
using BaseProject.WebApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApi.Controller
{
    public class AuthController : BaseController
    {
        [HttpPost("token")]
        [ProducesResponseType(typeof(LoginModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostToken([FromBody] LoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Register([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
