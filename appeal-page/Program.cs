var builder = WebApplication.CreateBuilder(args);

//controller ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// get default route => controller/action/id? (optional id)
app.MapDefaultControllerRoute();
 //app.MapControllerROute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
