using LinqToDB;
using LinqToDB.AspNet;
using RepositoryLayer.Data;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repository;
using ServicesLayer.Interfaces;
using ServicesLayer.Services;
using UILayer.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLinqToDBContext<ApplicationDataConnection>((provider,options)=>
   options.UseSqlServer(builder.Configuration.GetConnectionString("PersonInfo")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILanguageServices, LanguageServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IPersonInfoIndifferentLanguagesServices,PersonInfoIndifferentLanguagesServices>();
builder.Services.AddScoped<IPersonFactory, PersonFactory>();
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
