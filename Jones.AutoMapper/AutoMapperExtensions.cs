using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Jones.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddJonesAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        public static IServiceCollection AddJonesAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configAction)
        {
            services.AddAutoMapper(configAction, AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        
        public static T ToDto<T>(this IModel model, IMapper mapper) where T : IDto
        {
            return mapper.Map<T>(model);
        }
    }
}