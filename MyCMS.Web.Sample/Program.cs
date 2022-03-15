using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyCMS.Web.Sample.Data;
using MyCMS.Web.Sample.Data.Articles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ArticleService>();

builder.Services
    .AddMyCMSClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7040/graphql/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
