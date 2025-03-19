using EFCoreFluentValidation.Entities;
using FluentValidation;

namespace EFCoreFluentValidation.ServiceExtensions
{
    public static class ValidatiorServiceExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Blog>, BlogValidator>();
            services.AddScoped<IValidator<Author>, AuthorValidator>();
            services.AddScoped<IValidator<Comment>, CommentValidator>();
            services.AddScoped<IValidator<Category>, CategoryValidator>();
            services.AddScoped<IValidator<Tag>, TagValidator>();
            services.AddScoped<IValidator<Address>, AddressValidator>();

        }
    }
}
