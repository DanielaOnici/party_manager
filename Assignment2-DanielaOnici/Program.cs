/* Assignment2_DanielaOnici.sln
 * 
 * PROG2230 - Sec1 - Assignment2
 * Created by Daniela Onici
 * 
 * Revistion history:
 * 
 *      Created: 2022-11-9
 *      Added and fixed relationships: 2022-11-10
 *      Fixed controllers and email logic: 2022-11-12
 *      Added cookies and finished program: 2022-11-13
 * 
 */


using Assignment2_DanielaOnici.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connStr = builder.Configuration.GetConnectionString("PartyDOnici4297");
builder.Services.AddDbContext<PartyDBContext>(options => options.UseSqlServer(connStr));


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
