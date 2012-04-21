namespace BackboneJsOnNancy.Web.Modules
{
    using BackboneJsOnNancy.Web.Models.Authentication;
    using Nancy;
    using Nancy.ModelBinding;

    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule(IUserService userService)
        {
            bool preLoadAppStaticContent = Cassette.Nancy.CassetteStartup.ShouldOptimizeOutput;


            Get["/login"] = x =>
                            {
                                ViewBag.preLoadAppStaticContent = preLoadAppStaticContent;
                                return View["authentication/login"];
                            };

            Post["/login"] = x =>
                             {
                                 var ioc = new TinyIoC.TinyIoCContainer();
                                 x = ioc.Resolve<LoginModel>();

                                 var model = this.Bind<LoginModel>();
                                 var guid = userService.Authenticate(model.Username, model.Password);
                                 if (guid == null)
                                     return Response.AsRedirect("~/login?error=true");

                                 return Response.AsRedirect("~/login");
                             };

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