
namespace BackboneJsOnNancy
{
    using Cassette.Nancy;
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            CassetteStartup.ShouldOptimizeOutput = false;
        }
    }
}