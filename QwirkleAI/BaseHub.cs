using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public abstract class BaseHub
	{
        //private string serverIp = "http://172.24.53.76:52367/hub";
        private string serverIp = "http://localhost:52367/hub";
        protected HubConnection connection;

        protected BaseHub()
		{
			connection = new HubConnectionBuilder().WithUrl(serverIp).Build();
			registerEvent();
			ConnectToServer();
        }

        private void registerEvent()
		{
			//closed event
			connection.Closed += async (error) =>
			{
				await Task.Delay(new Random().Next(0, 5) * 1000);
				await connection.StartAsync();
			};
		}

        private void ConnectToServer()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {

            });

            try
            {
                connection.StartAsync().Wait();
                Console.WriteLine("Base Hub Connection started.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in connecting to Server.{ex.Message}");
            }
        }
	}
}