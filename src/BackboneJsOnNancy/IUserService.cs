namespace BackboneJsOnNancy
{
    using System;
    using Nancy.Authentication.Forms;

    public interface IUserService : IUserMapper
    {
        User GetUser(Guid id);
        Guid? Authenticate(string username, string password);
    }
}