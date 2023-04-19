
using Employee.Common.Behaviours;
using Employee.LoggerExtention;
using Employee.Model;
using Employee.Swagger_Documentation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using NLog;


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddControllers();
//.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddApiVersioningConfigured();//builder.Services.AddScoped<IDataccess, Dataccess>();
//builder.Services.AddMediatR(typeof(Dataccess).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<EmpDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Constring")));

//builder.Services.AddValidatorsFromAssembly(typeof(Dataccess).Assembly);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddSingleton<IloggerError, LoggerError>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
 //app.UseExceptionHandler("");
app.UseHttpsRedirection();
//app.UseStatusCodePages();
app.UseAuthorization();

app.MapControllers();
app.AddGlobalErrorHandler();
app.Run();
