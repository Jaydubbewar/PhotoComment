using Microsoft.EntityFrameworkCore;
using PhotoComment.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register your DbContext
builder.Services.AddDbContext<PhotoContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-B32GVO4\\SQLEXPRESS;Database=PhotoDB;TrustServerCertificate=True;Trusted_Connection=True;");
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
    name: "AddComment",
    pattern: "PhotoCom/AddComment",  // Adjust the pattern as needed
    defaults: new { controller = "PhotoCom", action = "AddComment" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PhotoCom}/{action=Index}/{id?}");

app.Run();
