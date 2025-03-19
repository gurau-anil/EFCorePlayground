using System;
using EfCoreCodeFirst.Data;
using EfCoreCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Registering ApplicationDbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty, options =>
    {
        options.CommandTimeout(30);
    });
    options.UseSeeding((context, _) =>
    {
        var testBlog = context.Set<Blog>().FirstOrDefault();
        if (testBlog == null)
        {
            context.Set<Blog>().Add(new Blog { Name ="Seeded Name" , Url = "http://seededUrl.com" });
            context.SaveChanges();
        }
    })
    .UseAsyncSeeding(async (context, _, cancellationToken) =>
    {
        var testBlog = context.Set<Blog>().FirstOrDefaultAsync();
        if (testBlog == null)
        {
            context.Set<Blog>().Add(new Blog { Name = "Seeded Name", Url = "http://seededUrl.com" });
            await context.SaveChangesAsync();
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
