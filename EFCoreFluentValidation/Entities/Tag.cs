using FluentValidation;

namespace EFCoreFluentValidation.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }

    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Tag name is required")
                .MaximumLength(100).WithMessage("Tag name cannot exceed 100 characters");
        }
    }

}
