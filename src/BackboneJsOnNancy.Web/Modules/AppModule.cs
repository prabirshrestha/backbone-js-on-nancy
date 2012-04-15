
namespace BackboneJsOnNancy.Web.Modules
{
    using Nancy;

    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = x => View["/index"];
        }
    }
}