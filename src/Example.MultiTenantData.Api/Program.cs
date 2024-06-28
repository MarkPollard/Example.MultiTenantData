using System.Reflection;

using Swashbuckle.AspNetCore.SwaggerUI;

using Example.MultiTenantData.Api.DI;
using Example.MultiTenantData.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.ConfigureApiServices(builder.Configuration);

var app = builder.Build();

// Configure the App
var apiVersion = Assembly.GetExecutingAssembly()!.GetName()!.Version!.Major;
app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/spec.json"; })
        .UseSwaggerUI(c =>
        {
            c.RoutePrefix = "swagger";
            c.SwaggerEndpoint($"v{apiVersion}/spec.json", $"Example Multi Tenant Data v{apiVersion}");
            c.DocExpansion(DocExpansion.None);
            c.EnableDeepLinking();
        });
app.UseHealthChecks($"/v{apiVersion}/healthcheck");
app.UseRouting();
app.UseCors("AllowAll");
app.UseMiddleware<MultiTenantMiddleware>();
app.UseMiddleware<MultiTenantClaimsMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
