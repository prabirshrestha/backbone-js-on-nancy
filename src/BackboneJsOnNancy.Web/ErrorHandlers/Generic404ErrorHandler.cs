namespace BackboneJsOnNancy.Web.ErrorHandlers
{
    using Extensions;
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.ViewEngines;

    public class Generic404ErrorHandler : IErrorHandler
    {
        private readonly IViewFactory _factory;
        private readonly IViewLocationCache _cache;

        public Generic404ErrorHandler(IViewFactory factory, IViewLocationCache cache)
        {
            _factory = factory;
            _cache = cache;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = _factory.RenderView(_cache, context, "views/errors/404.cshtml");

            // RenderView sets the context.Response.StatusCode to HttpStatusCode.OK
            // so make sure to override it correctly
            response.StatusCode = HttpStatusCode.NotFound;
        }
    }
}