namespace BackboneJsOnNancy
{
    using System.Configuration;

    public class Constants
    {
        public static readonly string DefaultConnectionString = ConfigurationManager.ConnectionStrings["BackboneJsOnNancyMongoDb"].ConnectionString;
    }
}