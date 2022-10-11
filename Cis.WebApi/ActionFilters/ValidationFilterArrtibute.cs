using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.WebApi.ActionFilters
{
    public class ValidationFilterArrtibute: IActionFilter
    {
        public ValidationFilterArrtibute()
        {

        }
        public void OnActionExecuting(ActionExecutingContext executingContext)
        {
            var action = executingContext.RouteData.Values["action"];
            var controller = executingContext.RouteData.Values["controller"];

            var param = executingContext.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
            if(param is null)
            {
                executingContext.Result = new BadRequestObjectResult($"Object is null: {controller}, action: {action}");
                return;
            }
            if (!executingContext.ModelState.IsValid)
                executingContext.Result = new UnprocessableEntityObjectResult(executingContext.ModelState);
        }
        public void OnActionExecuted(ActionExecutedContext executedContext)
        {

        }
    }
}
