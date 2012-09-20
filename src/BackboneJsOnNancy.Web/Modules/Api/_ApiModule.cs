namespace BackboneJsOnNancy.Web.Modules.Api
{
    using Nancy;

    public abstract class ApiModule : NancyModule
    {
        protected ApiModule()
            : base("/api")
        {
        }

        protected ApiModule(string modulePath)
            : base(string.Format("/api{0}", modulePath))
        {
        }
    }
}