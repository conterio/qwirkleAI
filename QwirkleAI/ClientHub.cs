using System;
using Microsoft.AspNetCore.SignalR.Client;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public class ClientHub : BaseHub
    {
        private readonly IAIBusi _aiBusi;
        private string yourName = "Jeremy's";

        public ClientHub(IAIBusi aiBusi)
        {
            _aiBusi = aiBusi;

            RegisterAI();
            Initialize();
        }

        private async void RegisterAI()
        {
            try
            {
                await connection.InvokeAsync("Register", $"{yourName} AI", false);
                Console.WriteLine($"{yourName} AI Registered");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{yourName} could not register.");
                throw;
            }
        }

        private void Initialize()
        {
            connection.On<Guid>("JoinGame", (gameId) =>
            {
                _aiBusi.CreateAIJoinGame(gameId);
            });
        }
    }
}
