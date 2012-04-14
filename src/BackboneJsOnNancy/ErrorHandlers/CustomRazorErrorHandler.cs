namespace BackboneJsOnNancy.ErrorHandlers
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.ErrorHandling;
    using Nancy.ViewEngines;

    public abstract class CustomRazorErrorHandler : IErrorHandler
    {
        private readonly IViewFactory _factory;
        private readonly IViewLocationCache _cache;

        protected CustomRazorErrorHandler(IViewFactory factory, IViewLocationCache cache)
        {
            _factory = factory;
            _cache = cache;
        }

        public abstract bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context);

        public abstract string HandleWithViewName(HttpStatusCode statusCode, NancyContext context);

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var viewNameWithoutExtension = HandleWithViewName(statusCode, context);
            var foundMatchingView = _cache.Any(x =>
                x.Name.Equals(viewNameWithoutExtension) &&
                x.Extension.Equals("cshtml", StringComparison.OrdinalIgnoreCase));

            if (foundMatchingView)
            {
                var viewContext =
                    new ViewLocationContext { Context = context };

                var viewName =
                    string.Concat(viewNameWithoutExtension, ".cshtml");

                context.Response = _factory.RenderView(viewName, null, viewContext);
                // _factory.RenderView sets the context.Response.StatusCode to HttpStatusCode.OK
                // so make sure to overried it correctly
                PostHandle(statusCode, context);
            }
        }

        public virtual void PostHandle(HttpStatusCode statusCode, NancyContext context)
        {
            context.Response.StatusCode = statusCode;
        }
    }
}