namespace BackboneJsOnNancy
{
    using System;
    using Nancy.Authentication.Forms;
    using Nancy.Security;

    public class UserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }
    }
}