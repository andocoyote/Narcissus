using Narcissus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Narcissus.UserInterface;

namespace Narcissus
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            ContainerBuilder.ConfigureServices(serviceCollection);

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            IUserInterface ui = services.GetRequiredService<IUserInterface>();

            // If you don't await this call, execution of the current method continues before the call is completed
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs4014?f1url=%3FappId%3Droslyn%26k%3Dk(CS4014)
            await ui.Run();
        }
    }
}