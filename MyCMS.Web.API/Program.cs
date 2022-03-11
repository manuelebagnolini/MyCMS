using MyCMS.Data;
using MyCMS.Data.DataProviders;
using MyCMS.Web.API.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dataProviderType = builder.Configuration
    .GetSection("DBSettings")
    .GetValue<DataProviderType>("DataProviderType");

builder.Services.AddSingleton<IDataProviderManager, DataProviderManager>();
builder.Services.AddSingleton(serviceProvider =>
    serviceProvider.GetRequiredService<IDataProviderManager>().GetDataProvider(dataProviderType));

builder.Services.AddDbContext<MyCMSContext>();

builder.Services.AddGraphQLServer()
    .AddQueryType<ContentQuery>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
