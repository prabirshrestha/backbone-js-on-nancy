namespace BackboneJsOnNancy.ErrorHandlers
{
    using Nancy;
    using Nancy.ViewEngines;

    public class Generic404ErrorHandler : CustomRazorErrorHandler
    {
        public Generic404ErrorHandler(IViewFactory factory, IViewLocationCache cache)
            : base(factory, cache)
        {
        }

        public override bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public override void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            RenderView(context, "404");

            // RenderView sets the context.Response.StatusCode to HttpStatusCode.OK
            // so make sure to override it correctly
            context.Response.StatusCode = HttpStatusCode.NotFound;
        }
    }
}