using CleanArchitectureWorkshop.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWorkshop.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        return services.AddScoped<ITeamsUseCase, TeamUsesCase>();
    }
}

