
namespace BackboneJsOnNancy.Web
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Nancy.Bootstrapper;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

#if !DEBUG
            Cassette.Nancy.CassetteStartup.ShouldOptimizeOutput = true;
#endif
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