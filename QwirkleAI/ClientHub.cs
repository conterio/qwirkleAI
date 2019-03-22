using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace QwirkleAI
{
	public class ClientHub
	{

		private HubConnection connection;
		public List<string> messagesList;

		public ClientHub(string ip)
		{
			messagesList = new List<string>();
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

		private async void ConnectToServer()
		{
			connection.On<string, string>("ReceiveMessage", (user, message) =>
			{
				messagesList.Add(message);
			});

			try
			{
				await connection.StartAsync();
				messagesList.Add("Connection started");

			}
			catch (Exception ex)
			{
				
				messagesList.Add(ex.Message);
			}
		}

		private async void RegisterAI()
		{
            try
            {
                await connection.InvokeAsync("Register", "Basic AI", false);
                //messageList.Add("AI Registered");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
		}
	}
}