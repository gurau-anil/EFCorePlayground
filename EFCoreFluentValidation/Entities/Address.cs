using FluentValidation;

namespace EFCoreFluentValidation.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("Street is required")
                .MaximumLength(100).WithMessage("Street cannot exceed 100 characters");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(50).WithMessage("City cannot exceed 50 characters");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("State is required")
                .MaximumLength(50).WithMessage("State cannot exceed 50 characters");

            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(50).WithMessage("Country cannot exceed 50 characters");

            RuleFor(a => a.AuthorId)
                .GreaterThan(0).WithMessage("Invalid author reference");
        }
    }

}
