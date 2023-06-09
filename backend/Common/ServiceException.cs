using System.Net;

namespace backend.Common
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public override string Message { get; } = null!;

        public ServiceException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static ServiceException NotFound(string message = "Id is not found")
        {
            return new ServiceException(HttpStatusCode.NotFound, message);
        }

        public static ServiceException Unauthorized(string message = "Unauthorized")
        {
            return new ServiceException(HttpStatusCode.Unauthorized, message);
        }

        public static ServiceException BadRequest(string message = "Bad Request")
        {
            return new ServiceException(HttpStatusCode.BadRequest, message);
        }

    }
}