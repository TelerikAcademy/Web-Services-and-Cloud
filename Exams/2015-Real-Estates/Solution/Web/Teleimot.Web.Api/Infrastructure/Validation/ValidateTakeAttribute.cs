namespace Teleimot.Web.Api.Infrastructure.Validation
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Common.Constants;

    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateTakeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var takeValue = (int?)actionContext.ActionArguments
                .Where(a => a.Key == "take")
                .Select(a => a.Value)
                .FirstOrDefault();

            if (takeValue > WebConstants.MaxTakeQuery)
            {
                actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"You cannot take more than {WebConstants.MaxTakeQuery} elements!");
            }
        }
    }
}
