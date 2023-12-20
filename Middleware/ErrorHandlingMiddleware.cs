using GabriEShopAPI.Exceptions;
using System.Net;
using System.Text.Json;

namespace GabriEShopAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                // log the error

                var response = context.Response;
                response.ContentType = "application/json";

                // get the response code and message

                //response.StatusCode = (int)404;

                //await response.WriteAsync(JsonSerializer.Deserialize(exception));

                switch (error)
                {
                    case NotFound e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ItemAlreadyExists e:
                        response.StatusCode= (int)HttpStatusCode.BadRequest;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }

    }
}
