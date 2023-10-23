using Empathy.Data.Entities;
using Empathy.Data;
using Empathy.Helpers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(Ew =>
{
    Ew.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
    Ew.SignIn.RequireConfirmedEmail = true;
    Ew.User.RequireUniqueEmail = true; //E-mail Unico
    Ew.Password.RequireDigit = false;
    Ew.Password.RequiredUniqueChars = 0;
    Ew.Password.RequireLowercase = false;
    Ew.Password.RequireNonAlphanumeric = false;
    Ew.Password.RequireUppercase = false;
    Ew.Password.RequiredLength = 6;
    Ew.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    Ew.Lockout.MaxFailedAccessAttempts = 3;
    Ew.Lockout.AllowedForNewUsers = true;

})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/NotAuthorized";
    options.AccessDeniedPath = "/Account/NotAuthorized";
});

//Inyecciones
builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IComboxHelper, ComboxHelper>();
builder.Services.AddScoped<IBlobHelper, BlobHelper>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();
SeedData();

void SeedData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();