using System.Net;

namespace HandlingExtinguishers.Core.Helpers
{
    public class GlobalException: Exception
    {
        public GlobalException(string message) : base(message)
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.StatusCode = HttpStatusCode.NotFound;
        }

        public GlobalException(IEnumerable<string> errors) : base(string.Join("", errors))
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }

        public GlobalException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.StatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }
    }
}
