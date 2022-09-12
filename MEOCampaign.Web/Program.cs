
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Core.Interfaces.Services;
using MEOCampaign.Core.Services;
using MEOCampaign.Infra.Data.Context;
using MEOCampaign.Infra.Data.Repositories;
using MEOCampaign.Infra.Data.Services;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString: connection));

builder.Services.AddScoped<ICitizenRepository, CitizenRepository>();
builder.Services.AddScoped<ICitizenService, CitizenService>();
builder.Services.AddScoped<ICitizenAddressRepository, CitizenAddressRepository>();
builder.Services.AddScoped<ICitizenAddressService, CitizenAddressService>();

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

app.UseAuthorization();

DatabaseManagementService.MigrationInitialization(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
