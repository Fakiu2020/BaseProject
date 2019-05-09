using System.Linq;
using Whoever.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Whoever.Web.ActionFilter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when the action is executing.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ActionArguments.Any(x => x.Value == null))
            {
                actionContext.Result = new BadRequestObjectResult("Arguments cannot be null.");
            }
            else if (!actionContext.ModelState.IsValid)
            {
                var response = new ServiceErrorResult(actionContext.ModelState);
                actionContext.Result = new BadRequestObjectResult(response);
            }
        }
    }
}