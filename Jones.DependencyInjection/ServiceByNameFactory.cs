﻿using System;
using System.Collections.Generic;

namespace Jones.DependencyInjection
{
    internal class ServiceByNameFactory<TService> : IServiceByNameFactory<TService> where TService : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, Type> _registrations;

        public ServiceByNameFactory(IServiceProvider serviceProvider, IDictionary<string, Type> registrations)
        {
            _serviceProvider = serviceProvider;
            _registrations = registrations;
        }

        public TService? GetByName(string name)
        {
            if (!_registrations.TryGetValue(name, out var implementationType))
                throw new ArgumentException("No service is registered for given name");
            return (TService?) _serviceProvider.GetService(implementationType);
        }
    }
}
