namespace BackboneJsOnNancy
{
    using System;
    using Nancy;
    using Nancy.Security;

    public class UserService : IUserService
    {
        private static readonly Guid AdminGuid = new Guid("7E2EA61D-519F-4DCF-BFCB-D66935CD51B4");

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return GetUser(identifier);
        }

        public User GetUser(Guid id)
        {
            if (id != AdminGuid)
                return null;

            return new User
                       {
                           Id = 1,
                           UserName = "admin@nancyfx.org",
                           Claims = new[] { "admin" }
                       };
        }

        public Guid? Authenticate(string username, string password)
        {
            return username == "admin@nancyfx.org" && password == "admin@123" ? (Guid?)AdminGuid : null;
        }
    }
}