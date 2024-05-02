using FluentValidation;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Concrete;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Concrete;
using OneMusic.DataAccessLayer.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IAlbumDal, EFAlbumDal>();
builder.Services.AddScoped<IAlbumService, AlbumManager>();

builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();

builder.Services.AddScoped<ISingerDal, EFSingerDal>();
builder.Services.AddScoped<ISingerService, SingerManager>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<OneMusicContext>();


builder.Services.AddControllersWithViews();

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
