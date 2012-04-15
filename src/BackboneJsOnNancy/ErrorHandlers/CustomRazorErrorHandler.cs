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
        public abstract void Handle(HttpStatusCode statusCode, NancyContext context);

        public void RenderView(NancyContext context, string viewName, dynamic model = null)
        {
            var foundMatchingView = _cache.Any(x =>
                x.Name.Equals(viewName) &&
                x.Extension.Equals("cshtml", StringComparison.OrdinalIgnoreCase));

            if (foundMatchingView)
            {
                var viewContext = new ViewLocationContext { Context = context };

                context.Response = _factory.RenderView(viewName, model, viewContext);
            }
        }
    }
}