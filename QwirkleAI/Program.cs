using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using QwirkleAI.Models;

namespace QwirkleAI
{
	class Program
	{
		static void Main(string[] args)
		{
			//string hostIp = "http://172.24.53.76:52367/hub";
			string hostIp = "http://localhost:52367/hub";



			var clientHub = new ClientHub(hostIp);

			foreach (var item in clientHub.MessagesList)
			{
				Console.WriteLine(item);
			};


            //Get Players
            var result = clientHub.connection.InvokeAsync<List<Player>>("GetAvailablePlayers").Result;
            foreach (var player in result)
            {
                Console.WriteLine($"PlayerName: {player.Name}");
            }


            //Create Game
            var gameSettings = new GameSettings();
            var game = clientHub.connection.InvokeAsync<Game>("CreateGame", gameSettings).Result;
        }






	}
}
