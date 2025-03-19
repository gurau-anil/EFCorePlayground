
using FluentValidation;

namespace EFCoreFluentValidation.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }

    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

            RuleFor(b => b.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters");

            RuleFor(b => b.AuthorId)
                .GreaterThan(0).WithMessage("Invalid author reference");
        }
    }


}
