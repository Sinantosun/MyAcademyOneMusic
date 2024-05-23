using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Concrete;
using OneMusic.BusinessLayer.ValidationRules;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Concrete;
using OneMusic.DataAccessLayer.Context;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.DAL;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<AppUser, AppRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<OneMusicContext>().AddErrorDescriber<CustomErrorDescriber>().AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => { opts.TokenLifespan = TimeSpan.FromMilliseconds(60); });

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IAlbumDal, EFAlbumDal>();
builder.Services.AddScoped<IAlbumService, AlbumManager>();

builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();


builder.Services.AddScoped<ISongDal, EFSongDal>();
builder.Services.AddScoped<ISongService, SongManager>();

builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDal, EFMessageDal>();



builder.Services.AddScoped<IMailService, MailManager>();


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<OneMusicContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(opts => { opts.Filters.Add(new AuthorizeFilter()); });
builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Login/Index"; options.AccessDeniedPath = "/ErrorPages/Page403"; options.Cookie.Name = Guid.NewGuid().ToString(); options.ExpireTimeSpan = TimeSpan.FromMinutes(1); options.SlidingExpiration = true; options.LogoutPath = "/Login/LogOut/"; });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPages/Page404", "?code{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
