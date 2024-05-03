using FluentValidation;
using MovieDB.Application.Dtos;

namespace MovieDB.WebApi.Validators
{
    public class UserValidator: AbstractValidator<UserDto>

    {
           public UserValidator()
            {
                RuleFor(j => j.Name).NotEmpty().MaximumLength(100);
                RuleFor(j => j.Email).NotEmpty().EmailAddress();
                RuleFor(j => j.Password).NotEmpty().MinimumLength(8)
                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")
                    .WithMessage("A senha deve ter no mínimo 8 caracteres, uma letra maiúscula, uma letra minúscula e um número.");
            }
        }
    }

