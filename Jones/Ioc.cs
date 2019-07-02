using System;

namespace Jones
{
    public class Ioc
    {
        private static IServiceProvider _serviceProvider;

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>() where T : class
        {
            return GetService<T>(typeof(T));
        }

        public static T GetService<T>(Type classType) where T : class
        {
            return (T) _serviceProvider.GetService(classType);
        }

        public static object GetService(Type classType)
        {
            return _serviceProvider.GetService(classType);
        }
    }
}