using FluentValidation;

namespace EFCoreFluentValidation.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
    }
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("Comment content is required")
                .MaximumLength(1000).WithMessage("Comment cannot exceed 1000 characters");

            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters");

            RuleFor(c => c.BlogId)
                .GreaterThan(0).WithMessage("Invalid blog reference");
        }
    }

}
