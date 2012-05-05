namespace BackboneJsOnNancy.Web.Tests
{
    using Nancy.Testing;
    using Xunit;

    public class Tests
    {
        [Fact]
        public void Test()
        {
            var bootstrapper = new TestBootstrapper();
            var browser = new Browser(bootstrapper);

            browser.Get("/login", with => with.HttpRequest());
        }
    }
}