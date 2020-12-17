using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Jones.DependencyInjection
{
    /// <summary>
    /// Provides easy fluent methods for building named registrations of the same interface
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public class ServicesByNameBuilder<TService> where TService : class
    {
        private readonly IServiceCollection _services;

        private readonly IDictionary<string, Type> _registrations
            = new Dictionary<string, Type>();

        internal ServicesByNameBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// Maps name to corresponding implementation.
        /// Note that this implementation has to be also registered in IoC container so
        /// that <see cref="IServiceByNameFactory&lt;TService&gt;"/> is be able to resolve it.
        /// </summary>
        public ServicesByNameBuilder<TService> Add(string name, Type implementationType)
        {
            _registrations.Add(name, implementationType);
            return this;
        }

        /// <summary>
        /// Generic version of <see cref="Add"/>
        /// </summary>
        public ServicesByNameBuilder<TService> Add<TImplementation>(string name)
            where TImplementation : TService
        {
            return Add(name, typeof(TImplementation));
        }

        /// <summary>
        /// Adds <see cref="IServiceByNameFactory&lt;TService&gt;"/> to IoC container together with all registered implementations
        /// so it can be consumed by client code later. Note that each implementation has to be also registered in IoC container so
        /// <see cref="IServiceByNameFactory&lt;TService&gt;"/> is be able to resolve it from the container.
        /// </summary>
        public void Build()
        {
            var registrations = _registrations;
            //Registrations are shared across all instances
            _services.AddTransient<IServiceByNameFactory<TService>>(s => new ServiceByNameFactory<TService>(s, registrations));
        }
    }
}