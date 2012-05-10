namespace BackboneJsOnNancy.Web.Models.Authentication
{
    using FluentValidation;

    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(m => m.Username).NotEmpty().WithMessage("Email required");
            RuleFor(m => m.Username).EmailAddress().WithMessage("Invalid email address");

            RuleFor(m => m.Password).NotEmpty().WithMessage("Password required");
            RuleFor(m => m.Password).Length(5, 25).WithMessage("Password length must be between 5-25 characters long");
            RuleFor(m => m.ConfirmPassword).NotEmpty().WithMessage("Confirm Password required");

            RuleFor(m => m.ConfirmPassword).Equal(m => m.Password).WithMessage("Password and Confirm password does not match");
        }
    }
}