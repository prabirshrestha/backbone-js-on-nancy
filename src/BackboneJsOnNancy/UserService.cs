namespace BackboneJsOnNancy
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.Security;

    public class UserService : IUserService
    {
        private readonly static IDictionary<Guid, Tuple<User, string>> _users = new ConcurrentDictionary<Guid, Tuple<User, string>>();

        static UserService()
        {
            _users.Add(new Guid("981ddc9a2b214d35be79b8706d15e1c1"), new Tuple<User, string>(new User { Id = 1, UserName = "admin@nancyfx.org", Claims = new[] { "admin" } }, "admin@123"));

        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return GetUser(identifier);
        }

        public User GetUser(Guid id)
        {
            Tuple<User, string> u;
            if (_users.TryGetValue(id, out u))
                return u.Item1;
            return null;
        }

        public Guid? Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Value.Item1.UserName == username && u.Value.Item2 == password);
            return user.Key == default(Guid) ? null : (Guid?)user.Key;
        }
    }
}