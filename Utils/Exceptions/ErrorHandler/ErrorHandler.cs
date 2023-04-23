using Microsoft.AspNetCore.Mvc;
using WebApi2.Models.Message;

namespace WebApi2.Utils.Exceptions.ErrorHandler
{
    public class ErrorHandler:ControllerBase
    {

        public static ActionResult<Response> Handle(HttpResponse resp, Func<Response> callback)
        {
            Response res;
            try
            {
                res = callback();
                resp.StatusCode = res.meta.GetStatusCode();
            }
            catch (ExceptionBase ex)
            {
                resp.StatusCode = ex.GetStatusCode();
                Meta meta = new Meta.Builder(ex.GetMessage())
                    .WithStatusCode(ex.GetStatusCode())
                    .WithErrorCode(ex.GetErrorCode())
                    .Build();
                res = new Response.Builder(meta).Build();
            }
            return new ErrorHandler().StatusCode(res.meta.statuscode, res);
        }

    }
}
