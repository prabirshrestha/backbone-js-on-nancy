namespace BackboneJsOnNancy.Web.Models.Authentication
{
    using FluentValidation;

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(m => m.Username).NotEmpty().WithMessage("Username required");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password required");
        }
    }
}