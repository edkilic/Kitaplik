using Kitaplik.Business;
using Kitaplik.Data;
using Kitaplik.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// KitaplikDbContext i�in DbContext ayarlar�
builder.Services.AddDbContext<KitaplikDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// KGelenDbContext i�in DbContext ayarlar�
//builder.Services.AddDbContext<KGelenDbContext>(options =>    options.UseSqlServer(builder.Configuration.GetConnectionString("KGelenDb")));

// Servisleri ekleme
builder.Services.AddScoped<IKitapRepository, KitapRepository>();
builder.Services.AddScoped<KitapService>();

// MVC ile controller ve view'lar�n eklenmesi
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Kitap}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Route ayarlar�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Kitap}/{action=Index}/{id?}");

app.Run();

