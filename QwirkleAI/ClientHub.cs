using System;
using Microsoft.AspNetCore.SignalR.Client;
using QwirkleAI.Models;

namespace QwirkleAI
{
    public class ClientHub : BaseHub
    {
        private readonly IAIBusi _aiBusi;

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
                await connection.InvokeAsync("Register", "Basic AI", false);
                MessagesList.Add("AI Registered");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Initialize()
        {
            connection.On<Guid>("JoinGame", (gameId) =>
            {
                _aiBusi.CreateAIJoinGame(null, gameId);
                var game = connection.InvokeAsync<Game>("JoinGame", gameId).Result;
            });
        }
    }
}
