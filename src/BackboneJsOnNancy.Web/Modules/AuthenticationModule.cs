namespace BackboneJsOnNancy.Web.Modules
{
    using Nancy;

    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule()
        {
            bool preLoadAppStaticContent = Cassette.Nancy.CassetteStartup.ShouldOptimizeOutput;

            Get["/login"] = x => "login";
            Get["/logout"] = x => "logout";

            Get["/register"] = x =>
                               {
                                   ViewBag.preLoadAppStaticContent = preLoadAppStaticContent;
                                   return View["authentication/register"];
                               };

            Post["/register"] = x =>
                                {
                                    return Response.AsRedirect("~/register?success=true");
                                };
        }
    }
}