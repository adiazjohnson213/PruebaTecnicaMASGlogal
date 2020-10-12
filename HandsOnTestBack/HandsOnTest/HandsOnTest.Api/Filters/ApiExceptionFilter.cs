using HandsOnTest.Business.Exeption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HandsOnTest.Api.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            if (context.Exception is HandsOnTestException)
            {
                var businessException = context.Exception as HandsOnTestException;

                context.Result = new JsonResult(new
                {
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Message = businessException.ExceptionMessage
                });
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = context.HttpContext.Response.StatusCode,
                    Message = "Un error no controlado ha ocurrido."
                });
            }

            base.OnException(context);
        }
    }
}
