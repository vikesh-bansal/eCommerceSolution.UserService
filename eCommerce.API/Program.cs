using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validator;
using FluentValidation;



var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();//Add Core services


//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly); // atleast one datamapper is required, as it inherited from profile so rest are automatically mapped by system.

//Add swagger generation services to create swagger specificication
builder.Services.AddSwaggerGen();

//Add cors Services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
});

// Build the web application
var app = builder.Build();
//Add Exception Handling middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
app.UseSwagger(); // Adds endpoint that can server the swagger.json
app.UseSwaggerUI();// Adds swagger UI (interactive page to explore the test API endpoints)

app.UseCors(); // Allow application with different domain can use this API or we enable this for Angular

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();
app.Run();
