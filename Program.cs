
using BlazingPizza.Data;
using NHibernate;
using ISession = NHibernate.ISession;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(factory =>
    NHibernateHelper.CreateSessionFactory(builder.Configuration));
builder.Services.AddScoped<PizzaService>();

builder.Services.AddScoped(factory =>
{
    var sessionFactory = factory.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var session = scope.ServiceProvider.GetRequiredService<ISession>();
    await PizzaSpecialSeed.SeedAsync(session);
}

app.Run();