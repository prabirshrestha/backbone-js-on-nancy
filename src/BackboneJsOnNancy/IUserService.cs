namespace BackboneJsOnNancy
{
    using System;
    using Nancy.Authentication.Forms;

    public interface IUserService : IUserMapper
    {
        Guid? Authenticate(string username, string password);
    }
}