using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BaseProject.Application.Roles;
using BaseProject.Application.Users.Commands.UpdateUser;
using BaseProject.Application.Users.Queries.GetAllUsers;
using BaseProject.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApi.Controller
{
    public class RoleController : BaseController
    {
      
        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RolesViewModel>> GetAll([FromQuery] GetRolesListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

       

    }
}
