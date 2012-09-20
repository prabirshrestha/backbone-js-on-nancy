namespace BackboneJsOnNancy.Web.Modules
{
    using System;
    using BackboneJsOnNancy.Web.Models.Authentication;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.ModelBinding;
    using Nancy.Validation;

    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule(BackbonJsOnNancyService service)
        {
            bool preLoadAppStaticContent = Cassette.Nancy.CassetteNancyStartup.OptimizeOutput;

            Get["/login"] = x =>
                            {
                                if (Context.CurrentUser != null)
                                    return Response.AsRedirect("~/");

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

                                 var guid = service.Authenticate(model.Username, model.Password);
                                 if (guid == null)
                                     return Response.AsRedirect("~/login?error=true");

                                 DateTime? expiry = null;
                                 if (model.RememberMe)
                                     expiry = DateTime.UtcNow.AddDays(14); // 2 weeks

                                 return this.LoginAndRedirect(guid.Value, expiry, "~/");
                             };

            Get["/logout"] = x => this.LogoutAndRedirect("~/");

            Get["/register"] = x =>
                               {
                                   if (Context.CurrentUser != null)
                                       return Response.AsRedirect("~/");

                                   ViewBag.preLoadAppStaticContent = preLoadAppStaticContent;
                                   return View["authentication/register"];
                               };

            Post["/register"] = x =>
                                {
                                    if (Context.CurrentUser != null)
                                        return Response.AsRedirect("~/");

                                    var model = this.Bind<RegisterModel>();
                                    var validationResult = this.Validate(model);
                                    ViewBag.errors = validationResult;

                                    if (!validationResult.IsValid)
                                    {
                                    }

                                    ViewBag.preLoadAppStaticContent = preLoadAppStaticContent;
                                    return View["authentication/register"];
                                };
        }
    }
}