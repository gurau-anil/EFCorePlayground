using EfCoreCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //We can do this here or it can be handled with dependency injection approach 

            //Eg. We can register the ApplicationDbContext as builder.Services.AddDbContext<ApplicationDbContext>(options=>{
            // options.UseSqlServer(connectionString)
            //})

            optionsBuilder.UseSqlServer("ConnectionString");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(model =>
            {
                model.ToTable("Blogs");
                model.HasKey(c => c.Id);
                model.HasMany(c => c.Posts).WithOne(c => c.Blog);

                //seeding Data (Data is seeded when migration is run to update the databse)

                //model.HasData(new Blog()
                //{
                //    Id = 1,
                //    Name = "Test Blog",
                //    Url = "This is a test Url"
                //});
            });

            modelBuilder.Entity<Post>(model =>
            {
                model.ToTable("Posts");
                model.HasKey(c => c.Id);
                model.HasOne(c => c.Blog).WithMany(c => c.Posts);
                model.Property(c => c.Content).HasColumnName("Description").IsRequired(false);
                //model.HasData(
                //    new Post
                //    {
                //        Id = 1,
                //        Title = "Test Title",
                //        Content = "This is a test content",
                //        BlogId = 1  // Foreign key to the Blog entity
                //    },
                //    new Post
                //    {
                //        Id = 2,
                //        Title = "Test Title002",
                //        Content = "This is a test content002",
                //        BlogId = 1  // Foreign key to the Blog entity
                //    }
                //);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
