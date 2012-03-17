
namespace BackboneJsOnNancy
{
    using Cassette.Configuration;
    using Cassette.Scripts;

    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {
            // Please read http://getcassette.net/documentation/configuration

            bundles.Add<ScriptBundle>("assets/javascripts/header", b => b.PageLocation = "header");

            bundles.Add<ScriptBundle>("assets/javascripts/libs", b => b.PageLocation = "libs");

            bundles.Add<ScriptBundle>("assets/javascripts/app", b => b.PageLocation = "app");
        }
    }
}