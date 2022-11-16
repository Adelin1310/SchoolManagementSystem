using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    public static class ErrorHandler
    {
        public static ActionResult ResponseCodeHandler(int statusCode, object res)
        {
            switch (statusCode)
            {
                case 200:
                    return new OkObjectResult(res);
                case 404:
                    return new NotFoundObjectResult(res);
                case 500:
                    return new StatusCodeResult(500);
                case 400:
                    return new BadRequestObjectResult(res);
                case 401:
                    return new UnauthorizedObjectResult(res);
                default:
                    return new StatusCodeResult(500);
            }

        }
    }
}