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
        public HubConnection connection;
        public List<string> MessagesList;

        protected BaseHub()
		{
			MessagesList = new List<string>();
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
	}
}