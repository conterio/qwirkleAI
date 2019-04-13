using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public class ClientApp
    {
        private readonly ClientHub _clientHub;
		static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        public ClientApp(ClientHub clientHub)
        {
            _clientHub = clientHub;
        }
        public void Run()
        {
			//foreach (var item in _clientHub.MessagesList)
			//{
			//    Console.WriteLine(item);
			//};


			////Get Players
			//var result = _clientHub.connection.InvokeAsync<List<Player>>("GetAvailablePlayers").Result;
			//foreach (var player in result)
			//{
			//    Console.WriteLine($"PlayerName: {player.Name}");
			//}


			////Create Game
			//var gameSettings = new GameSettings();
			//var game = _clientHub.connection.InvokeAsync<Game>("CreateGame", gameSettings).Result;



			Console.CancelKeyPress += (sender, eArgs) =>
			{
				_quitEvent.Set();
				eArgs.Cancel = true;
			};
			//Kick off asynchronous stuff
			_quitEvent.WaitOne();


			Console.WriteLine("test");
			//cleanup and shutdown
        }
    }
}