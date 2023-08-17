using constructionCompanyAPI.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace constructionCompanyAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ConstructionCompanyDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().Matches(@"^(?=.{1,255}$)(?=.{1,64}@.{1,255}$)(?=.{1,64}@.{1,253}\.[a-zA-Z0-9-]{2,63}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Invalid email format.");

            RuleFor(x => x.Password).Custom((password, context) =>
            {
                if (password.Length < 8)
                {
                    context.AddFailure(nameof(RegisterUserDto.Password), "Password must be at least 8 characters long.");
                }
                else if (!ContainsRequiredCharacters(password))
                {
                    context.AddFailure(nameof(RegisterUserDto.Password), "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
                }
            });

            RuleFor(x => x.ConfirmPassword).Equal(p => p.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(x => x.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }

            });

        }
        private bool ContainsRequiredCharacters(string password)
        {
            return
                password.Any(char.IsUpper) &&
                password.Any(char.IsLower) &&
                password.Any(char.IsDigit) &&
                password.Any(IsSpecialCharacter);
        }

        private bool IsSpecialCharacter(char c)
        {
            var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            return specialCharacters.Contains(c);
        }
    }
}
