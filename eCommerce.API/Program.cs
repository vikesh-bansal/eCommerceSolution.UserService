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
builder.Services.AddControllers().AddJsonOptions(options=> options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly); // atleast one datamapper is required, as it inherited from profile so rest are automatically mapped by system.
 
// Build the web application
var app = builder.Build();
//Add Exception Handling middleware
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();
app.Run();
