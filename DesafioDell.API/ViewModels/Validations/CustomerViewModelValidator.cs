using FluentValidation;

namespace DesafioDell.API.ViewModels.Validations
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(customer => customer.Email).NotEmpty().WithMessage("Email cannot be empty");
            
        }

    }
}

