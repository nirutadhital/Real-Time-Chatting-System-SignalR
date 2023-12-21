using Signalrdemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

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
// app.UseEndpoints(endpoints =>
//  {
//      endpoints.MapHub<ChatHub>("/chatHub");
// //      endpoints.MapControllerRoute(
// //      name: "default",
// //      pattern: "index.html");
//  });
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapHub<ChatHub>("/chatHub"); // Check if your hub is mapped correctly
// });

#pragma warning disable ASP0014
app.UseEndpoints(e => {
    e.MapHub<ChatHub>("/chatHub");
});
#pragma warning restore ASP0014
// app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
