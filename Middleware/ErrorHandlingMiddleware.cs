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
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case NotFoundItem:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ItemAlreadyExists:
                        response.StatusCode= (int)HttpStatusCode.BadRequest;
                        break;

                    case ItemCannotBeDeleted:
                        response.StatusCode=(int)HttpStatusCode.Gone;
                        break;

                    case FailedToAdd:
                        response.StatusCode=(int)HttpStatusCode.Conflict;
                        break;

                    case FailedToUpdate:
                        response.StatusCode=(int)HttpStatusCode.Conflict;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }

    }
}
