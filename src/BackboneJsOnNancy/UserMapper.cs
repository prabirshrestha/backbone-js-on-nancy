namespace BackboneJsOnNancy
{
    using System;
    using Nancy.Authentication.Forms;
    using Nancy.Security;

    public class UserMapper : IUserMapper
    {
        public UserMapper()
        {
            
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }
    }
}