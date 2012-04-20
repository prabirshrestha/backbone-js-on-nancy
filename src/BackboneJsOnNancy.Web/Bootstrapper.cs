
namespace BackboneJsOnNancy.Web
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Nancy.Bootstrapper;
    using TinyIoC;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

#if !DEBUG
            Cassette.Nancy.CassetteStartup.ShouldOptimizeOutput = true;
#endif
            container.Register<IUserMapper, UserMapper>();

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

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(
                    x =>
                    {
                        x.ErrorHandlers = new List<Type>
                                              {
                                                  typeof (Api.ErrorHandlers.Api404ErrorHandler),
                                                  typeof (ErrorHandlers.Generic404ErrorHandler),
                                                  typeof (Nancy.ErrorHandling.DefaultErrorHandler),
                                              };
                    });
            }
        }
    }
}