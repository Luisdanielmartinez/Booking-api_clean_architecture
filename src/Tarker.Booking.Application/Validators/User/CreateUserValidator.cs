using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(X => X.FirstName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(X => X.LastName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(X => X.UserName).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(50);
            RuleFor(X => X.Password).NotNull().WithMessage("El campo no puede ser nulo").NotEmpty().MaximumLength(10);
        }
    }
}
