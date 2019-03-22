using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public class ClientHub
	{
        public HubConnection connection;
        public List<string> MessagesList;

		public ClientHub(string ip)
		{
			MessagesList = new List<string>();
			connection = new HubConnectionBuilder().WithUrl(ip).Build();


			registerEvent();

			ConnectToServer();
			RegisterAI();
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
                MessagesList.Add(message);
            });

            try
            {
                connection.StartAsync().Wait();
                MessagesList.Add("Connection started");

            }
            catch (Exception ex)
            {

                MessagesList.Add(ex.Message);
            }
        }

        private async void RegisterAI()
		{
            try
            {
                await connection.InvokeAsync("Register", "Basic AI", false);
                MessagesList.Add("AI Registered");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
		}
	}
}