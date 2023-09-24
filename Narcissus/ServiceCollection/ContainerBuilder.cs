using Narcissus.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Narcissus.DependencyInjection
{
    public static class ContainerBuilder
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // MenuInterface uses everything
            serviceCollection.AddSingleton<IUserInterface, Narcissus.MenuInterface.MenuInterface>();
        }
    }
}
