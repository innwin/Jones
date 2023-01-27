using Microsoft.Extensions.DependencyInjection;

namespace Jones.DependencyInjection;

public static class FactoryServiceCollectionExtensions
{
    /// <summary>
    /// Entry point for name-based registrations. This method should be called in order to start building
    /// named registrations for <typeparamref name="TService"/>"/>
    /// </summary>
    /// <returns><see cref="ServicesByNameBuilder&lt;TService&gt;"/> which is used to build multiple named registrations</returns>
    public static ServicesByNameBuilder<TService> AddByName<TService>(this IServiceCollection services) where TService : class
    {
        return new ServicesByNameBuilder<TService>(services);
    }
}