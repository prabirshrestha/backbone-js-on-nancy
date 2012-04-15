namespace BackboneJsOnNancy.Api.ErrorHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.Responses;

    public class Api404ErrorHandler : IErrorHandler
    {
        private readonly IEnumerable<ISerializer> _serializers;

        public Api404ErrorHandler(IEnumerable<ISerializer> serializers)
        {
            _serializers = serializers;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound && context.Request.Path.StartsWith("/api/");
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.Response = new JsonResponse(new { error = "path not found" }, _serializers.First(s => s.CanSerialize("application/json")));
        }
    }
}