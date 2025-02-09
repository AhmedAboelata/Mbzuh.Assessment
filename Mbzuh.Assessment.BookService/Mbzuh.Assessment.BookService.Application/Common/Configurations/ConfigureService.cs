using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mbzuh.Assessment.BookService.Application.Common.Configurations;

public static class ConfigureService
{
    public static IServiceCollection ConfigureBookServiceApplication(this IServiceCollection services)
    {
        var assemply = Assembly.GetExecutingAssembly();

        //AutoMapper
        services.AddAutoMapper(assemply);

        //Fluent Validation
        services.AddValidatorsFromAssembly(assemply).AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        //ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop; //Stop validation with first failure

        //MediatR
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(assemply); });

        return services;
    }
}
