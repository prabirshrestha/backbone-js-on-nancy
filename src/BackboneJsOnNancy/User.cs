namespace BackboneJsOnNancy
{
    using System.Collections.Generic;
    using Nancy.Security;

    public class User : IUserIdentity
    {
        public long Id { get; set; }

        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}