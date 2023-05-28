using AssingmentUsingDapper.Areas.Admin.MedicineServices;
using AssingmentUsingDapper.Areas.Admin.PatientServices;
using AssingmentUsingDapper.Areas.Admin.PriscriptionServices;
using AssingmentUsingDapper.Areas.User.MedicineServices;
using AssingmentUsingDapper.Areas.User.PatientServices;
using AssingmentUsingDapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserManagment, UserManagment>();
builder.Services.AddSingleton<IPatientServices, PatientServices>();
builder.Services.AddSingleton<IMedicineServices, MedicineServices>();
builder.Services.AddSingleton<IPatientServicesUser, PatientServicesUser>();
builder.Services.AddSingleton<IMedicineServicesUser, MedicineServicesUser>();
builder.Services.AddSingleton<IPatientDetailsService, PatientDetailsService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios,see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
