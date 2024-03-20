using IdentityServer;
using IdentityServerHost.Quickstart.UI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
      .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddTestUsers(Config.TestUser)
    .AddDeveloperSigningCredential();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.Run();
