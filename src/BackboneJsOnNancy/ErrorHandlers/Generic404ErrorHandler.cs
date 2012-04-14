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

        public override string HandleWithViewName(HttpStatusCode statusCode, NancyContext context)
        {
            return "404";
        }
    }
}