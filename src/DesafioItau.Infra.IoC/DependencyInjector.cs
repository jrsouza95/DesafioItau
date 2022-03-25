using DesafioItau.Application.UseCases.V1.CashWithdrawal.GetNotesCombination;
using DesafioItau.Domain.Interfaces;
using DesafioItau.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioItau.Infra.IoC;

public static class DependencyInjector
{
    public static void InjectDependencies(this IServiceCollection services)
    {
        InjectUseCases(services);
        InjectRepositories(services);
    }

    private static void InjectUseCases(IServiceCollection services)
    {
        services.AddScoped<IGetNotesCombinationUseCase, GetNotesCombinationUseCase>();
        services.Decorate<IGetNotesCombinationUseCase, GetNotesCombinationValidation>();
    }

    private static void InjectRepositories(IServiceCollection services)
    {
        services.AddScoped<IBanknoteRepository, BanknoteRepository>();
    }
}