using Microsoft.Extensions.DependencyInjection;
using System;

namespace QwirkleAI
{
    class Program
	{
		static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAIRepository, AIRepository>()
                .AddSingleton<IAIBusi, AIBusi>()
                .AddSingleton<ClientHub>()
                .AddSingleton<ClientApp>()
                .BuildServiceProvider();

            try
            {
                var aiRepository = serviceProvider.GetService<IAIRepository>();
                aiRepository.AddAI("TestConnecitonId");
                var aiBusi = serviceProvider.GetService<IAIBusi>();
                var clientApp = serviceProvider.GetService<ClientApp>();
                clientApp.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
	}
}