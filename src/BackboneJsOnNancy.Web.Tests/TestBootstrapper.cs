namespace BackboneJsOnNancy.Web.Tests
{
    using System;
    using System.IO;
    using Nancy.Testing;
    using Nancy.Testing.Fakes;

    public class TestBootstrapper : Bootstrapper
    {
        protected override Type RootPathProvider
        {
            get
            {
                var assemblyFilePath =
                    new Uri(typeof(Bootstrapper).Assembly.CodeBase).LocalPath;

                var assemblyPath =
                    Path.GetDirectoryName(assemblyFilePath);

                var rootPath =
                    PathHelper.GetParent(assemblyPath, 3);

                rootPath =
                    Path.Combine(rootPath, @"BackboneJsOnNancy.Web");

                FakeRootPathProvider.RootPath = rootPath;

                return typeof(FakeRootPathProvider);
            }
        }
    }
}