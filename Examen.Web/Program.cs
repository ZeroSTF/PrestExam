using AM.Infrastructure;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Examen.Infrastructure;
using Examen.Interfaces;
using Examen.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Injection de dépendance
builder.Services.AddDbContext<DbContext, ExamContext>();
//builder.Services.AddTransient<IEquipeService, EquipeService>();
//builder.Services.AddTransient<ITropheeService, TropheeService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));


//*******************
//builder.Services.AddScoped<IEquipeService, EquipeService>();
builder.Services.AddScoped<IPrestataireService, PrestataireService>();
builder.Services.AddScoped<IPrestationService, PrestationService>();

//................



// Add services to the container.
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
