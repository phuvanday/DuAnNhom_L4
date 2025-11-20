using AssignmentC4.Areas.User.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AssignmentC4_Context>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("YolaConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/// 🎯 Chuyển "/" về User/Home/Index
app.MapGet("/", context =>
{
    context.Response.Redirect("/User");
    return Task.CompletedTask;
});

/// 🎯 Route cho AREA — phải đặt TRÊN ROUTE DEFAULT
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

/// 🎯 Route mặc định — dành cho User
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
