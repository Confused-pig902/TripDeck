using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TripDeck.Repository.Models;
namespace TripDeck.Web
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TravelDestinationCarouselContext>(options => options.UseNpgsql(connectionString));
            services.AddHttpContextAccessor();
            RegisterImplementations(services, "TripDeck.Repository");
            RegisterImplementations(services, "TripDeck.Service");
        }
        private static void RegisterImplementations(IServiceCollection services, string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
            {
                throw new ArgumentException("Assembly name cannot be null or empty", nameof(assemblyName));
            }
            Assembly? assembly = Assembly.Load(assemblyName);
            Type[]? types = assembly.GetTypes();
            IEnumerable<Type>? interfaces = types.Where(t => t.IsInterface && t.Namespace is not null);
            IEnumerable<Type>? implementations = types.Where(t => t.IsClass && !t.IsAbstract && t.Namespace is not null);
            foreach (Type? serviceInterface in interfaces)
            {
                Type? implementation = implementations.FirstOrDefault(implementation => serviceInterface.Name[1..] == implementation.Name);
                if (implementation is not null)
                {
                    services.AddScoped(serviceInterface, implementation);
                }
            }
        }
    }
}