namespace BackboneJsOnNancy.Web.ErrorHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.Responses;

    public class Api500ErrorHandler : IErrorHandler
    {
        private readonly IEnumerable<ISerializer> serializers;

        public Api500ErrorHandler(IEnumerable<ISerializer> serializers)
        {
            this.serializers = serializers;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.InternalServerError && context.Request.Path.StartsWith("/api/");
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var serializer = serializers.First(s => s.CanSerialize("application/json"));

            var error = new
            {
                message = "Unknown error occurred",
#if DEBUG
                stackTrace = context.Items["ERROR_TRACE"]
#endif
            };

            var response = new JsonResponse(new { error }, serializer)
            {
                StatusCode = HttpStatusCode.InternalServerError
            };

            context.Response = response;
        }
    }
}