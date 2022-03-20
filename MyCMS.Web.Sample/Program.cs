using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyCMS.Web.Sample;
using MyCMS.Web.Sample.Data.Articles;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ArticleService>();

builder.Services
    .AddMyCMSClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7040/graphql"));

await builder.Build().RunAsync();
