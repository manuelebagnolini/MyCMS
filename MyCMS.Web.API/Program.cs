using MyCMS.Core.Interfaces;
using MyCMS.Data;
using MyCMS.Data.DataProviders;
using MyCMS.Data.Intefaces;
using MyCMS.Data.TestData;
using MyCMS.Web.API.GraphQL.Queries;
using MyCMS.Web.API.GraphQL.Types;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dataProviderType = builder.Configuration
    .GetSection("DBSettings")
    .GetValue<DataProviderType>("DataProviderType");

builder.Services.AddSingleton<IDataProviderManager, DataProviderManager>();
builder.Services.AddSingleton(serviceProvider =>
    serviceProvider.GetRequiredService<IDataProviderManager>().GetDataProvider(dataProviderType));

builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));

builder.Services.AddDbContext<MyCMSContext>();

builder.Services.AddGraphQLServer()
    .AddQueryType<ContentQuery>()
    .AddType<ContentObjectType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// Added just for test purpose
builder.Services.AddScoped<TestDataImporter>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// CORS policies for the sample Blazor WebAssembly frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_sampleWASM",
                      builder =>
                      {
                          builder
                            .WithOrigins("https://localhost:7058",
                                         "http://localhost:5059")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // enable CORS policies for sample WASM for development only
    app.UseCors("_sampleWASM");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
