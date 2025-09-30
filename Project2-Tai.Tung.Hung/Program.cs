using Microsoft.EntityFrameworkCore;
using Project2_TaiTungHung.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Lấy connection string từ appsettings.json (đúng key "DefaultConnection")
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CuaHangBanhNgotContext>(options =>
    options.UseSqlServer(connectionString));

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
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
// Route mặc định: gọi HomeController → TTHIndex
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=TTHIndex}/{id?}");

app.Run();
