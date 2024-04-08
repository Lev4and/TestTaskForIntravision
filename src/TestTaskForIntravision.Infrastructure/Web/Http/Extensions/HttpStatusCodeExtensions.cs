using System.Net;

namespace TestTaskForIntravision.Infrastructure.Web.Http.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static bool IsErrorStatusCode(this HttpStatusCode? code)
        {
            return code >= HttpStatusCode.BadRequest;
        }
    }
}
