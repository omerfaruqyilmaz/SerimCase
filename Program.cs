using Microsoft.EntityFrameworkCore;
using SerimCase.Business.Abstract.Command;
using SerimCase.Business.Abstract.Query;
using SerimCase.Business.Abstract.Service;
using SerimCase.Business.Concrete.Command;
using SerimCase.Business.Concrete.Query;
using SerimCase.Business.Concrete.Service;
using SerimCase.DataAccess.Concrete;
using SerimCase.DataAccess.Seed;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IDynamicCommandRepository, DynamicCommandRepository>();
builder.Services.AddScoped<IDynamicQuery, DynamicQuery>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<ProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Database:ConnectionString"]);
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

app.SeedData();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
