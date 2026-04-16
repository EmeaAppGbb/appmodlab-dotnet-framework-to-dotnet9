using Microsoft.EntityFrameworkCore;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Data.Repositories;
using NorthwindTechUniversity.Web.Mappings;
using NorthwindTechUniversity.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<NorthwindTechContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindTechContext")));

// Register repositories and Unit of Work
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<UnitOfWork>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<NorthwindTechContext>();
    NorthwindTechDbInitializer.Seed(context);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
