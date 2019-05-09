using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Application.Common.Administrators.Commands.DeleteAdministrator;
using BaseProject.Application.Users.Administrators.Commands.CreateAdministrator;
using BaseProject.Application.Users.Administrators.Commands.UpdateAdministrator;
using BaseProject.Application.Users.Administrators.Queries.GetAdministratorDetailQuery;
using BaseProject.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApi.Controller
{
    public class AdministratorController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Create([FromBody] CreateAdministratorCommand command)
        {
            var userId = await Mediator.Send(command);

            return CreatedAtRoute(RoutesName.GetAdministratorById, new { id = userId }, null);
        }
     
        [HttpGet("{id}", Name = RoutesName.GetAdministratorById)]
        [ProducesResponseType(typeof(AdministratorDetailModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<AdministratorDetailModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAdministratorDetailQuery { Id = id }));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateAdministratorCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete Administrator
        /// </summary>
        /// <param name="id">Identifier of the administrator</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAdministratorCommand { Id = id });
            return NoContent();
        }
    }
}
