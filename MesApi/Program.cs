using MesApi.Models;
using MesApi.Repository;
using MesApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataSourceContext>(opt =>
      {
          opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
          // opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
      });
builder.Services.AddCors();
builder.Services.AddScoped<ICommesseRepository, CommesseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors(X => X.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
