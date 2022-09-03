using FastEndpoints;
using FluentValidation;
using PersonMongoDbMinimalApi.Contracts.Requests;
using System.Text.RegularExpressions;

namespace PersonMongoDbMinimalApi.Validation.PersonValidation;
public class PersonBaseValidation<T> : Validator<T> where T: CreatePersonRequest
{
	public PersonBaseValidation()
	{
		RuleFor(x => x.FirstName)
			.MinimumLength(2)
			.WithMessage("First name must be at least 2 characters long")
			.MaximumLength(50)
			.WithMessage("First name must be at less than 50 characters");

            RuleFor(x => x.SecondName)
            .MinimumLength(2)
            .WithMessage("Second name must be at least 2 characters long")
            .MaximumLength(50)
            .WithMessage("Second name must be at less than 50 characters");

        RuleFor(vm => vm.Telephone)
               .NotEmpty()
               .WithMessage("Phone number is required")
               .MinimumLength(10)
               .WithMessage("Phone number length must be at least 10 characters long")
               .MaximumLength(20)
               .WithMessage("Phone number length must be less than 20 characters")
               .Matches(new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"))
               .WithMessage("Incorrect phone number format");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18)
            .WithMessage("You must be older 18");

        RuleFor(x=>x.Email)
            .NotEmpty()
            .WithMessage("Email address is required")
            .EmailAddress()
            .WithMessage("A valid email is required");
    }
}
