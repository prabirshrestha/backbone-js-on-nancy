namespace BackboneJsOnNancy
{
    using System.Collections.Generic;
    using System.Linq;
    using Nancy.Security;

    public class User : IUserIdentity
    {
        public User()
        {
            Claims = Enumerable.Empty<string>();
        }

        public long Id { get; set; }

        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}