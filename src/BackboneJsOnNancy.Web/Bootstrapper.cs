
namespace BackboneJsOnNancy
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using TinyIoC;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

#if !DEBUG
            Cassette.Nancy.CassetteNancyStartup.OptimizeOutput = true;
#endif
            container.Register<IUserService, UserService>();
            container.Register<IUserMapper>(container.Resolve<IUserService>());
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            FormsAuthenticationRequestStartup(container, pipelines, context);
        }

        private void FormsAuthenticationRequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            var config = new FormsAuthenticationConfiguration
                             {
                                 RedirectUrl = "~/login",
                                 UserMapper = container.Resolve<IUserMapper>()
                             };

            FormsAuthentication.Enable(pipelines, config);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", "public"));
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(
                    x =>
                    {
                        x.ErrorHandlers = new List<Type>
                                              {
                                                  typeof (ErrorHandlers.Generic404ErrorHandler),
                                                  typeof (ErrorHandlers.Api404ErrorHandler),
                                                  typeof(ErrorHandlers.Api500ErrorHandler),
                                                  typeof (Nancy.ErrorHandling.DefaultErrorHandler),
                                              };
                    });
            }
        }
    }
}