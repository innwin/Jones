namespace Jones.DependencyInjection
{
    /// <summary>
    /// Provides instances of registered services by name
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IServiceByNameFactory<out TService> where TService : class
    {
        /// <summary>
        /// Provides instance of registered service by name
        /// </summary>
        TService? GetByName(string name);
    }
}