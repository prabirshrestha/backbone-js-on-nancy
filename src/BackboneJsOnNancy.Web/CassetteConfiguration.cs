
namespace BackboneJsOnNancy.Web
{
    using Cassette.Configuration;
    using Cassette.HtmlTemplates;
    using Cassette.Scripts;
    using Cassette.Stylesheets;

    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {
            // Please read http://getcassette.net/documentation/configuration

            bundles.Add<StylesheetBundle>("assets/stylesheets/style.less",
                                          b => b.Processor = new StylesheetPipeline()
                                                                 .EmbedImages());

            bundles.Add<ScriptBundle>("assets/javascripts/header", b => b.PageLocation = "header");
            bundles.Add<ScriptBundle>("assets/javascripts/libs", b => b.PageLocation = "libs");
            bundles.Add<ScriptBundle>("assets/javascripts/app", b => b.PageLocation = "app");
            bundles.Add<ScriptBundle>("assets/javascripts/public_app", b => b.PageLocation = "public_app");

            bundles.Add<HtmlTemplateBundle>("assets/templates", b => b.Processor = new HoganPipeline { JavaScriptVariableName = "JST" });
        }
    }
}