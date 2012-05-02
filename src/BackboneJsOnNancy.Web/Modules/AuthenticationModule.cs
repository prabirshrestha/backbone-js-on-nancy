namespace BackboneJsOnNancy.Web.Modules
{
    using BackboneJsOnNancy.Web.Models.Authentication;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Validation;

    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule(IUserService userService)
        {
            bool preLoadAppStaticContent = Cassette.Nancy.CassetteStartup.ShouldOptimizeOutput;

            Get["/login"] = x =>
                            {
                                ViewBag.preLoadAppStaticContent = preLoadAppStaticContent;
                                ViewBag.error = Request.Query.error.HasValue && Request.Query.error.Value == "true";
                                    
                                return View["authentication/login"];
                            };

            Post["/login"] = x =>
                             {
                                 var model = this.Bind<LoginModel>();
                                 var validationResult = this.Validate(model);

                                 if (!validationResult.IsValid)
                                     return Response.AsRedirect("~/login?error=true");

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