namespace BackboneJsOnNancy.Modules
{
    using Nancy;

    public class AuthenticationModule : NancyModule
    {
        public AuthenticationModule()
        {
            Get["/login"] = x => "login";
            Get["/logout"] = x => "logout";

            Get["/register"] = x => "register";
        }
    }
}