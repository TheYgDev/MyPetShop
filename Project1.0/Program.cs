using App.DAL.DataContext;
using App.DAL.Repositories;
using App.DAL.Repositories.Contracts;
using App.BLL.Services;
using App.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using App.BLL.Services.EnttiyServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Configuration.AddUserSecrets<Program>();
string connectionString = builder.Configuration["ConnectionStrings:PetShop"]!;
builder.Services.AddDbContext<DbPetsContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));



builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IAnimalService,AnimalService>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//	var ctx = scope.ServiceProvider.GetRequiredService<DbPetsContext>();
//	ctx.Database.EnsureDeleted();
//	ctx.Database.EnsureCreated();
//}

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
	app.UseExceptionHandler("/Error/Index");
}

using (var scope = app.Services.CreateScope())
{
	var ctx = scope.ServiceProvider.GetRequiredService<DbPetsContext>();

	if (!ctx.Database.CanConnect())
	{
		ctx.Database.EnsureCreated();
	}
}
app.UseStatusCodePagesWithReExecute("/Error/Error404");
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();

