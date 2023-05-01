using System.Reflection;

namespace Client_Interface
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterViewModels(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var viewModelTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("ViewModel"));

            foreach (var viewModelType in viewModelTypes)
            {
                if (viewModelType != null)
                {
                    services.AddTransient(viewModelType);
                }
            }
        }
        public static void RegisterPages(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var pageTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Page"));

            foreach (var pageType in pageTypes)
            {
                if (pageType != null)
                {
                    services.AddTransient(pageType);
                }
            }
        }
        public static void RegisterRoutes(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var pageTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Page"));

            foreach (var pageType in pageTypes)
            {
                if (pageType != null)
                {
                    Routing.RegisterRoute(nameof(pageType), pageType);
                }
            }
        }
    }
}
