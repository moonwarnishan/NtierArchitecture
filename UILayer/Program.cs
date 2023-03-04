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
   options.UseSqlServer(builder.Configuration.GetConnectionString("PersonInfo") ?? string.Empty));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILanguageServices, LanguageServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IPersonInfoIndifferentLanguagesServices,PersonInfoIndifferentLanguagesServices>();
builder.Services.AddScoped<IPersonFactory, PersonFactory>();
builder.Services.AddScoped<ILanguageFactory, LanguageFactory>();
builder.Services.AddScoped<IPersonInDifferentLanguagesFactory, PersonInDifferentLanguagesFactory>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".PersonInfo.Session";
    options.Cookie.IsEssential = true;
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

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
