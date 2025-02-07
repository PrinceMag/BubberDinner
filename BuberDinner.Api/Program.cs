using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    //builder.Services.AddSingleton<ProblemDetailsFactory,BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    /*
    app.Map("/error", (HttpContext httpContext) =>
    {
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Results.Problem(title: exception?.Message, statusCode: 400);
    });
    */
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
