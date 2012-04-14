
namespace BackboneJsOnNancy
{
    using System;
    using System.Collections.Generic;
    using Cassette.Nancy;
    using Nancy;
    using Nancy.Bootstrapper;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            CassetteStartup.ShouldOptimizeOutput = false;
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
                                                  typeof(Nancy.ErrorHandling.DefaultErrorHandler),
                                              };
                    });
            }
        }
    }
}